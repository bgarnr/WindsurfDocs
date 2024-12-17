using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SemanticKernelDemo.Plugins;

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json");
var configuration = configBuilder.Build();

var apiKey = configuration["OpenAI:ApiKey"];
var modelId = configuration["OpenAI:ModelId"];
var orgId = configuration["OpenAI:OrgId"];

if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(modelId))
{
    Console.WriteLine("Please set your OpenAI credentials in appsettings.Development.json");
    return;
}

var kernelBuilder = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion(modelId: modelId, apiKey: apiKey, orgId: orgId);
kernelBuilder.Plugins.AddFromType<SpellNotePlugin>();
var kernel = kernelBuilder.Build();

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

Console.WriteLine("Chat with AI (type 'exit' to quit)");
Console.WriteLine("Try asking it to spell something backwards or save a note!");

// Initialize chat history
var chatHistory = new ChatHistory();

while (true)
{
    Console.Write("\nYou: ");
    var input = Console.ReadLine();
    
    if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
        break;

    try
    {
        // Add user message to history
        chatHistory.AddUserMessage(input);

         // Configure settings with auto function calling enabled
         var settings = new OpenAIPromptExecutionSettings
         {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
         };

      var currentResponse = "";
        
        // Stream the response
        await foreach (var update in chatCompletionService.GetStreamingChatMessageContentsAsync(
            chatHistory,
            settings,
            kernel))
        {
            if (!string.IsNullOrEmpty(update.Content))
            {
                Console.Write(update.Content);
                currentResponse += update.Content;
            }
        }
        Console.WriteLine();

        // Add assistant's response to history
        chatHistory.AddAssistantMessage(currentResponse);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

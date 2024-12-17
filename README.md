# Grounding for Windsurf 
## Semantic Kernel Auto Function Calling

Helper file: ConcatAllCodeFilesForAi.bat.txt
This is a bat file. It will find all the .cs and .razor files in the currenet directory and make a single file out of all the concatenated contents. I have found this useful if i want to setup an ai session with grounding on a topic like my models, or even just all the interfaces for my services because it can infer a great deal about the system from that.

Files under SemanticKernelRepoFIles are from the github repo for  Semantic Kernel at the time of version 1.31.0
https://github.com/microsoft/semantic-kernel

I strongly encourage getting the repo locally, running the examples, trying notebooks. I also have been air lifting files that are relevant to problems I am trying to solve into my Grounding folder for Windsurf.

The .windsurfrules can be edited to suit your specific needs. This goes in the root of your solution.

In my solution I have a root level folder with the pattern name: 
PROJECTNAME.Grounding

In this folder I keep folders of documents that I reference in Windsurf and Cursor when I want to provide additional grounding.

Make your folder, copy these files in.  

In Windsurf stay in chat mode, and use @ in chat to reference the docss.*. files and bring them into the context.

YOU: @docs 1, @docs2, etc I want to integreate auto function calling into my sytem. I have this plugig class @mypluginclass 
tell me how i can use autofunction calling of that class's functions in my service class @mychatservice 


# Semantic Kernel Demo with Windsurf
## A Console that calls some functions automatically

I had a chat session with Write enabled in windsurf where I referenced the files in the Demo.Grounding folder, specifically: docs.example_autofunctioncall_will_arguments_and_streaming

I started a new session with no solution or project file, just the grounding. With that I was able to ask windsurf to create a demo that would have semantic kernel auto function calling for 2 functions. 
One would spell a word backwards and one would append a note to a file. 

Windsurf had to create the solution, the project, the files and write the code. I provided a little direction and it did the rest.

Once it completed, I switched to visual studio 2022 preview to debug. 

You will need to update appsettings.Development.json with your openai credentials before this will run.


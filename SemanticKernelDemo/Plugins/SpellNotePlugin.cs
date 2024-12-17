using System;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SemanticKernelDemo.Plugins;

public class SpellNotePlugin
{
    [KernelFunction, DescriptionAttribute("Spells the input message backwards")]
    public string SpellItBackwards([DescriptionAttribute("The message to reverse")] string? msg)
    {
        if (string.IsNullOrEmpty(msg))
            return string.Empty;
            
        var charArray = msg.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    [KernelFunction, DescriptionAttribute("Saves a note to a text file")]
    public async Task<string> SaveNote([DescriptionAttribute("The message to save")] string? msg)
    {
        if (string.IsNullOrEmpty(msg))
            return "No message to save";
            
        await File.AppendAllTextAsync("notes.txt", $"{DateTime.Now}: {msg}{Environment.NewLine}");
        return "Note saved successfully";
    }
}

# Grounding for Windsurf 
## Semantic Kernel Auto Function Calling

The .windsurfrules can be edited to suit your specific needs. This goes in the root of your solution.

In my solution I have a root level folder with the pattern name: 
PROJECTNAME.Grounding

In this folder I keep folders of documents that I reference in Windsurf and Cursor when I want to provide additional grounding.

Make your folder, copy these files in.  

In Windsurf stay in chat mode, and use @ in chat to reference the docss.*. files and bring them into the context.

YOU: @docs 1, @docs2, etc I want to integreate auto function calling into my sytem. I have this plugig class @mypluginclass 
tell me how i can use autofunction calling of that class's functions in my service class @mychatservice 

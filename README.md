# AutoCoder-UI

Not much to say yet, really. It works. It works VERY well with mixtral models.

<<<<<<< HEAD
### 🔥 ime Capsule / Historical Flex
=======
### 🔥 Time Capsule / Historical Flex
>>>>>>> 558dfd1 (fixed typo)

**Yes, I invented the Ralph Loop before it had a name.**

This was my very first GitHub project (back when C# still felt tolerable).

Before tool calling existed.  
Before models were trained to use functions.  
Before Claude Code, Cursor, Aider, or any modern agent scaffolding.

I built a complete desktop agent harness that could:

- Run in full **auto-generation mode**
- Take a high-level `prompt.md` + a list of desired files
- Iteratively write an entire project by repeatedly feeding the model the current state of the filesystem
- Use the AI to improve the harness itself (self-referential bootstrapping, baby)

It was basically a **Ralph Loop** implemented the hard way, no fancy plugins, no stop hooks, no ReAct. Just raw prompting + persistent file state + a relentless outer loop.

I was doing this **3 years before** the "Ralph Wiggum Loop" became a thing in 2026.

Looking back, the code is gloriously janky (hardcoded paths, manual ChatML formatting, requires recompilation for some changes, etc.). But the core idea was there: let the model live in a persistent workspace and keep hammering the same goal until the project is done.

This project is the spiritual ancestor of everything I build now:
- **faCtMCP**: the tiny native C/C++ MCP backbone
- **editorMCP**: the 5.2 MB RAM editor with live editing <- in progress
- The upcoming **C++ just-bash + CerebroShell live terminal** <- almost in progress, editorMCP and faCtMCP are ready!

I eventually got fed up with C# ("fuck this language") and rewrote everything in proper C/C++, but this ugly little time capsule proves I was chasing the same vision the whole time:

**Make the AI help me build better AI tooling, damnit!**

So yeah… I was early.  
Really fucking early.

ChatML is currently hardcoded in for the chat feature, so its mostly targeted at openai use, but its configured by default to connect to a local server. LM Studio works well for this purpose. The initial tag is left off, and the whole blob is sent as the pre-prompt. With the baked in tags, it just works, with openai or Local models that auto-add the prompt format (Most do, or have an option to)

There are several good models that use chatml, and it was chosen as the model I use personally is dolphin-mixtral. It is the best at coding of any other model I've tested, even 70b llama-2 based ones. Only chatGPT-4 is better at coding.

Most stuff is currently hard-coded. I can only sped an hour or two a week working on this, but I took a simple console app, and made it somewhat more attractive for windows nerds at least.

I also improved the internal prompting massively, it consistantly produces viable projects now. You can also include a list of files in the readme.md and it will usually generate those as well during the file enumeration step.

Currently the only way to use the autogen is to edit the readme.md. running from the prompt bar is only partially and non-functionally implemented.

Settings and global variables are saved and loaded from XML files. Some properties are also in appsettings.json, those are the settings for the secondary, more robust but slower api. (The chat streaming feature.)

# How to use:

Enter text into the bottom text box and it send to chat in realtime!

Edit the prompt.md file with your prompt and watch as the smol developer backend goes to work! (What's left, I had to tear it apart quite a bit to get it to work as a Windows GUI app :)

It can take quite some time to get a response in autogen mode, that's normal as there is no token streaming in this mode.

Currently, by default you need a openai compatible local model or openai proxy server set up on port 1234 to use it. You can now change those settings in the app for the autogen feature only. Still need the proxie for streaming chat for now) If you have visual studio and a couple of minutes, you can edit the api-keys and urls that are still hardcoded and re-compile. All those things will be saved as a setting in a future version.


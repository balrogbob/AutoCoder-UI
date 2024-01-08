# AutoCoder-UI

Not much to say yet, really. It works. It works VERY well with mixtral models.

ChatML is currently hardcoded in for the chat feature, so its mostly targeted at openai use, but its configured by default to connect to a local server. LM Studio works well for this purpose. The initial tag is left off, and the whole blob is sent as the pre-prompt. With the baked in tags, it just works, with openai or Local models that auto-add the prompt format (Most do, or have an option to)

There are several good models that use chatml, and it was chosen as the model I use personally is dolphin-mixtral. It is the best at coding of any other model I've tested, even 70b llama-2 based ones. Only chatGPT-4 is better at coding.

Most stuff is currently hard-coded. I can only sped an hour or two a week working on this, but I took a simple console app, and made it somewhat more attractive for windows nerds at least.

I also improved the internal prompting massively, it consistantly produces viable projects now. You can also include a list of files in the readme.md and it will usually generate those as well during the file enumeration step.

Currently the only way to use the autogen is to edit the readme.md. running from the prompt bar is only partially and non-functionally implemented.

Settings and global variables are saved and loaded from XML files. Some properties are also in appsettings.json, those are the settings for the secondary, more robust but slower api. (The chat streaming feature.)

# How to use:

Enter text into the bottom text box and it send to chat in realtime!

Edit the readme.md file with your prompt and watch as the smol developer backend goes to work! (What's left, I had to tear it apart quite a bit to get it to work as a Windows GUI app :)

It can take quite some time to get a response in autogen mode, that's normal as there is no token streaming in this mode.

Currently, you need a openai compatible local model or openai proxy server set up on port 1234 to use it. If you have visual studio and a couple of minutes, you can edit the api-keys and urls that are still hardcoded and re-compile. All those things will be saved as a setting in a future version.


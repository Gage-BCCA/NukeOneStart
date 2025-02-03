# ☣️ NukeOneStart
Destroy the OneStart PUP with _extreme_ prejudice.

This program will:
- Kill running OneStart processes
- Delete the application by removing the program's files
- Remove common persistence techniques that I've seen
- Clean the Registry as much as feasible

⚠️*Warning*: This application touches the registry and System32 files, both of which are sensitive areas. I have tested this program on my local machine, and I have went through some
safety efforts, but caution should be taken. This software is distributed as is, and does not have any warranty.

## ❓ What Is OneStart?
OneStart.ai is an annoying Chromium-based browser that sneakily downloads itself onto workstations and sets up basic persistence to keep itself around. It serves pop-up ads and clickjacks. 
It stores user data and [totally doesn't sell it, trust us bro](https://onestart.ai/privacy-policy/).

It's annoying and shady, so I wrote this program to remove it.


## ℹ️ About This Program
This is probably over-engineered, and I've seen this exact thing accomplished with PowerShell scripts, but I wanted to create an PE file that I could drop on a computer, run with my admin credentials, and delete afterwards.

Plus, it was a fun exercise in C#.

### Naming Conventions
The bulk of the work is completed by the **Warheads**. This was a cute little naming convention, but I wanted to keep them labeled this because they can be dangerous. Some touch very sensitive portions of the Windows Operating System. 

### Documentation 
#### ➡️ OneStartRegistryHunter
This class mainly accomplishes cleaning the registry as much as feasible. It kills any registry keys that are set up by OneStart in the subkeys of the Users Hive. 

There are some keys in the TaskCache that the Windows Task Scheduler uses,
but not even the built-in admin account has permissions to write/delete to out of the box. You'll notice a method that iterates these keys, but it is not used. To delete the TaskCache keys, you'll need to adjust the
permissions on the Registry Hive, and modify this method or delete them by hand.

I don't feel as if the TaskCache is a reasonable enough threat for these actions, and I have not taken them. Once you run this program, it will delete the scheduled task, but since the TaskCache is untouched, it will still appear in the Scheduled Task list.
Not a big deal, though, as it won't actually run.

#### ➡️ OneStartFolderHunter
This class deletes all OneStart app data folders for all users, as well as any scheduled task in %SystemRoot%\System32\Tasks that includes the name "OneStart".

#### ➡️ OneStartProcessHunter
This class' job is to find and kill any OneStart processes that are currently running.

## Contact Me
I created this and will work on this program sporadically, but this is all based on my own observations and experience with this not-so-awesome piece of software. If you have additional things that I can add (like process
names, files, folders, registry keys, etc), feel free to reach out and I'd be more than happy to add them.

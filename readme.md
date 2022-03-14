# convert-to-vp9

## What is it?
convert-to-vp9 is a simple .NET Core console app I tossed together to try and make it easier for non tech-savvy people to convert video files to VP9/WEBM.  VP9 is useful in the playback of transparent videos used within scenes and browser sources on OBS/XSplit.

## Why do I need this?
As streamers start upping their content game, they're wanting to do more complex animations both in OBS, as well as within their browser sources.  VP9 is a great format for this, as it supports alpha channel video (which can be exported using apps like DaVinci Resolve, Fusion, Adobe After Effects, etc.)

## How do I download it?
Head on over to the [Releases](https://github.com/SharpDressedPenguin/convert-to-vp9/releases) page and download the latest release.

## Why not use FFMPEG?
Actually, I do!  Under the covers, this uses `ffmpeg` and `ffprobe` to handle the conversion.  In fact, this is the equivalent command I'm using to convert the videos to VP9:

```
ffmpeg -i input.mov -c:v libvpx-vp9 out.webm
```

While I could simply use `ffmpeg` to do the conversion, that involves downloading and installing `ffmpeg`, and using the console and dealing with file paths.  I wanted something that was cross-platform, fairly easy to use, and just works.

## Why not use an app like Handbrake?

Because Handbrake doesn't support VP9 with alpha.  If folks from the Handbrake project read this, please add support!

## Holy crap!  The EXE is over 200 MB!

Yup!  To make things as easy as possible for end users, the executable bundles the app, the .NET 6.0 runtime (around 50 MB), as well as a version of `ffmpeg` and `ffprobe` (75 MB each).  The actual app is only 150k.

While I may provide just the app executable for those who want to use their own `ffmpeg` version, bundling everything together produces a single binary that should run consistently no matter what .NET Framework runtime is installed.

Also, there's nothing stopping you from cloning the repo and compiling it yourself.  That's the beauty of open-source projects.  🙂

## How does it work?
### You can drag files onto the icon to process them instantaneousy:
![Dragging and dropping video files onto the icon](gifs/drag-and-drop.gif)

### You can drag each file individually into the window:
![Dragging and dropping video files onto the icon](gifs/individual-files.gif)

### You can even copy/paste a list into the window:
![Dragging and dropping video files onto the icon](gifs/copy-paste-list.gif)

## Where do my files go?
The resulting WEBM files are dumped in the same folder as the source file.

## I found a bug, or have an idea for a new feature!
Create an issue in Github, and I'll try to respond as I have time.
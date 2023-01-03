
# Repository Cleaner

<p>A simple tool that can help clean up a Visual Studio solution that scans directories passed as arguments for 'bin' and 'obj' directories and removes them.</p>
<p>It will scan the directory tree and any 'bin' and 'obj' folders that are in the same directory as a '.csproj' file and attempt to delete.</p>

## Example usage

<p>From the command line:</p>

>`C:\path-to\RepoCleaner.exe "c:\my-repos-folder"`

<p>Within visual studio</p>

>Debug|RepoCleaner Debug Properties|Command line arguments

![Screenshot 2023-01-03 120440](https://user-images.githubusercontent.com/23365872/210354157-e3a55b69-d2d4-4cef-a806-532f1157a42b.png)

## Screenshot

<p>Here's a screenshot of it after a run.</p>

![Screenshot 2023-01-03 121444](https://user-images.githubusercontent.com/23365872/210355675-320074f9-fe4e-4370-a16d-6c99d2a816e0.png)

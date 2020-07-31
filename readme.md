# Changelog
Version 20.1.0, 2020 July 28.

New:
- Thumbnails are created of not only videos, but pictures too, with a limited size, to speed up loading and avoid out of memory issue.
- Info box can be shown during video/image playback by pressing I. Works for external files too. Close it by pressing Esc or Enter.
- Exif data is shown in info box
- In actual size view, going to next or previous picture retains the zoom, and the position too if the new image has the same dimensions as the previous one.
- Deleting is possible while the info box is open.
- Pressing Home and End moves cursor to first/last thumbnail

Changed:
- Pressing left or right always goes to previous/next file. Use Shift for frame by frame video playback and Ctrl for moving an image larger than the screen
- The window is not longer switching to full screen when opening a video/picture. 
- Thumbnails are now not loading in the background when opening external file. This will start up the program faster.

Bugs fixed:
- Vertical videos are rotated to landscape
- When selecting a comment, and pressing esc, the comment closes. When pressing Esc again, the video does not exit.
- When pressing R at media view, the program becomes unresponsive to keypresses.

Version 18.5.0, 2018 August 10.

New feature:
- Pictures can be enlarged (or shrinked) to actual size. Use the icon in the controls bar, or press A. Enlarged pictures can be moved around using the mouse or the arrows.
Esc will shrink an enlarged picture to fit screen, and the left/right keys can be again used to step to the previous/next file.
When you first enlarge a picture, it will be centered, but if you drag it to a different position, it will be remembered, when switching to screen size and actual size again.  
Pictures smaller than screen will appear in actual size at first, and can be toggled to fit screen. Thumbnails are not affected. 
Speed of moving images with arrows can be set in settings.

Bugs fixed:
- When renaming a directory which contains pictures, those pictures cannot be opened afterwards, shown info or renamed.
Thumbnails are unnecessarily refreshed, when switching to another app, and returning to this one. Also when changing file name separator in settings.
- When video finishes, frame by frame starts from where we last used it instead of the beginning of the video.
- When frames are finished extracting, step by step goes to the beginning of the video.
- If the frames of a video started extracting in thumbnail view, and we open the video,  after frames extraction is finished, frame by frame requires double keypress towards the end of the video.
- When pressing I in video/picture view, info will show when we exit the media. 
- When deleting multiple files, a click on a thumbnail will not open it. A second click is needed.
- Saving settings with Ctrl+S would not work, when the cursor is in a text box.

Version 18.4.0, 2018 July 26.

New feature:
- Tab order changed: Directory list -> Thumbnails -> Controls bar
- Functions added to clicking on the gray area of the thumbnail list: If the focus is not on the thumbnails, or no thumbnail is selected, it sets the focus, and puts active selection to first thumbnail / last actively selected thumbnail.
If there is thumbnail selected, it unselects all.

Bugs fixed:
- List scrolling jumps while dragging, the currently selected directory cannot get out of view. (Introduced in 18.3.0 as a result of the last bug fix.)
- Active selection disappears when dragging.
- Ctrl+Click on currently selected directory results in freeze.
- Clicking on the gray area of the thumbnail list makes the thumbnail list active without visible active selection (passive selection can be moved with the arrows). New functions are now added to this click, see above.
- Select one thumbnail, and another with red. When you start to drag, selection changes: The red selection becomes active green, and the other selected item disapears.
- If you select a thumbnail, move the mouse away, so it is not over any image, pressing the R key to rename selected has no effect. Navigating selection with the arrows is disabled afterwards. 
- When selecting a thumbnail, and navigating away using the tab, pressing R and I will still open up the rename and file info fields, if the mouse is over a thumbnail.
Now this is disabled. Keys have search function, when the focus is on the directory list. Delete key still works from anywhere.

Version 18.3.0, 2018 July 23.

New feature:
- Ability to nagivate through settings page with Tab / Shift+Tab.

Bugs fixed:
- When renaming a non-empty directory by only changing the case, an error message would come.
- Possibility to create directory by pressing F7, or opening the list's context menu, when no start directory is set.
- When switching to another app, and renaming the currenly selected folder, upon returning to the program an error message would come. When deleting / renaming the currently selected folder in external app, the first item would get selected upon returning to the program. Now the selection index doesn't change, except if we deleted the last directory in the list.
- Context menu items "rename" and "delete" would be visible, when right-clicking the root directory.
- If File Name Separator is contained in a video's file name, thumbnail generation would stop there, and the "Updating thumbnais..." status would remain. 
Now File Name Separator is allowed in file names, except for files in the root folder.
- Errors (freezes), when renaming directory / file outside of program, and returning to the program.
- Select multiple files. Open the last file by navigating the active rectangle with the keys, and with Shift+Right go to next file. The media view closes, and the active selection disappears as it should. Now press Tab until the active selection reappears over the thumbnails. It will be over the first image, may be red or green, and that image remains selected after you move the rectangle away from it.
Now it is changed, so in case there are multiple selected files, the first of them will get the active selection.
- When the thumbnail list has the focus, opening the settings will make a thin dotted line visible over the settings page.
- Active selection of a thumbnail disappears when opening settings, and closing it by pressing the Cancel or Save buttons.
- When creating / renaming / deleting directory (in or outside of program), pressing the up and down keys to navigate the selection puts it to the top of the list. Now the selected directory can be navigated, but when you have created a directory, and you press the arrows once, it just puts the focus on the item (thin dotted line), and another keypress is required to move it. Other times the dotted line may not appear immediately, but the selection moves on the first keypress. 

Version 18.2.0, 2018 July 20.

New feature:
- When dragging a file over to the list of folders, the list will scroll, if the mouse is at the bottom or top of the list. The sensitive areas are 10 px high.

Bugs fixed: 
- When unselecting thumbnails, and navigating away with the tab, when the focus gets on the thumbnails again, the selection rectangle is red, if if was like that before removing selection.
- When you press R to rename a selected file, the bright green (active) selection would disappear, and not reappear after finishing the rename. Hence you would not be able to navigate the selection afterwards.
- Active selection would disappear when closing file info box with mouse click.
- Moving / copying files into a program whose start directory is not set. Files would be moved to c:\Users\{user}\AppData\Local\VirtualStore\
Now a message box will appear, and no operation happens.

Version 18.1.0, 2018 July 19.

- If a comment is selected, but not in editing mode, the controls auto hide, if the mouse is away from the bottom of the screen. Also when selecting a comment position (Alt Gr + 1-9 or Alt Gr + Left / Right), the controls will not automatically appear.
When comments are set to hiding, pressing Esc will close the currently selected comment. The controls have to be visible for this behaviour, otherwise the video just exits. 
- Errors fixed: Renaming a directory with only the case changed, or when the name is not changed.
New directory that has identical name to an existing one, or only differs by case can be created, and it will overwrite the existing one after confirmation. 
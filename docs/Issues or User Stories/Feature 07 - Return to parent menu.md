As a user,
I need to be able to leave each menu and return to its parent menu,
So that I can continue using the application.

Acceptance Criteria:
* Each sub-menu (each menu except the main menu) has a menu item/option to exit the sub-menu and return to its parent.
* To ensure consistency, this menu item should be the last option in the menu.
* When this menu item is selected, the current menu exits. The menu that spawned the current menu re-displays.
    * Exiting the Student Details menu returns to Classroom Details.
    * Exiting the Classroom Details menu returns to the main menu.

Notes:
* If you make any changes to a student (add/remove/grade assignments, etc.), then exit the Student Details menu, then go back into Student Details for the same student, you need to see the changes that you made (e.g., any assignments that were added still need to be present). 
* If you make any changes to a classroom (add/remove students, modify students through the Student Details menu, etc.), then exit the Classroom Details menu, then go back into Classroom Details for the same classroom, you need to see the changes that you made (e.g., any students that were added still need to be present, with the same assignments, etc. that they had when you left). 

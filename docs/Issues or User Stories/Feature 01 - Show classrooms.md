As a user,
I need to be able to show a list of classrooms,
So that I can see which classrooms have been added.

Acceptance Criteria:
* When the main menu displays, it includes an option/menu item to show classrooms.
* When this menu item is selected, a list of classroom names (just the names) is displayed.
* After the list is displayed, the user has a chance to view it, and then the main menu re-displays.

Notes:
* If the console is cleared when the main menu re-displays, then you will need to do something so the user can view the list before it disappears. One solution is to ask the user to press a key (or to press Enter), and then to wait for user input using Console.ReadKey (or Console.ReadLine).
* Some information may not be fully specified and is left up to the developer's discretion. In a real-world scenario, you would want to confirm these details with the client (probably through your scrum master or product owner). Examples include:
    * What is the exact wording of the show classrooms menu option?
    * What order does the show classrooms option appear in, in relation to any other menu options?

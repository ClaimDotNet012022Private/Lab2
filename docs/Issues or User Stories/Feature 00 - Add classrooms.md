As a user,
I need to be able to add classrooms by name using a text menu,
So that I can manage the classrooms.

Acceptance Criteria:
* When the program is run, a text menu displays (other stories will refer to this menu as the "main menu".
* The main menu has a menu item/option to add a classroom.
* After the main menu displays, the user is asked to select one of the available options.
* When the add classroom option is selected, the user is asked for the name of a new classroom to add.
* Once the user enters a name, a new classroom is created with that name and added to the classrooms that the program is managing.
* After the classroom is added, the main menu re-displays.

Notes:
* Some information may not be fully specified and is left up to the developer's discretion. In a real-world scenario, you would want to confirm these details with the client (probably through your scrum master or product owner). Examples include:
    * What exactly does the menu look like? Is there a descriptive header at the top? What does the prompt look like?
    * What is the exact wording of the add classroom menu option?
    * How are menu options identified/chosen? 
        * Are they numbers? Must those numbers be consecutive, or can there be gaps? Is the first option 0 or 1?
        * Are they characters or strings? Do they start with 'A' and count consecutively, or are they more arbitrary? When compared to the user's input, is the comparison case-sensitive?
    * What happens if the user enters a name that already exists?
        * Display a message telling about the error? And then what? (Ask for a different name, and keep going until the user gets it right? Just go immediately back to the main menu?)
        * Create the new classroom and replace the old one that had the same name? (I would prefer _not_ to do this)
        * Do nothing?

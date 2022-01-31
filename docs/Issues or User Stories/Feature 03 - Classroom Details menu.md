As a user, 
I need to be able to edit classroom details by name,
So that I have a way to manage the classroom.

Acceptance Criteria:
* When the main menu displays, there is a menu item/option for classroom details.
* When this option is selected, the user is asked for the name of a classroom.
* Once the user enters a name, a Classroom Details menu is displayed.
* The instance of the Classroom Details menu is associated with the classroom whose name the user entered.

Notes:
* It's a good idea to show the classroom name somewhere (perhaps in a header section above the menu options) when the Classroom Details menu displays. That way, you can be sure you're getting the menu associated with the classroom correctly.
* Some information may not be fully specified and is left up to the developer's discretion. In a real-world scenario, you would want to confirm these details with the client (probably through your scrum master or product owner). Examples include:
    * What is the exact wording of the classroom details menu option?
    * What order does this menu item appear in, in relation to any other menu items?
    * What happens if no classrooms have been added?
    * What happens if the user enters a name that doesn't exist (hasn't been added as a classroom)?
    * What exactly does the Classroom Details menu look like? Is there a heading of some sort?

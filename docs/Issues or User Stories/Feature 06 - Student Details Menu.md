As a user, I need to have a menu for student details,
So that I can manage each student's assignments and information.

Acceptance Criteria:
* When the Classroom Details menu displays, there is a menu item/option for student details.
* When this option is selected, the user is asked for the name of a student in the current classroom.
* Once the user enters the name of a student in the current classroom, a Student Details menu is displayed.
* The instance of the Student Details menu is associated with the student whose name the user entered.

Notes:
* It's a good idea to show the student's name somewhere when the Student Details menu displays. That way, you can be sure you're getting the menu associated with the student correctly.
* Some information may not be fully specified and is left up to the developer's discretion. In a real-world scenario, you would want to confirm these details with the client (probably through your scrum master or product owner). Examples include:
    * What is the exact wording of the student details menu option?
    * What order does this menu item appear in, in relation to any other menu items?
    * What happens if no students have been added to the classroom?
    * What happens if the user enters a name that doesn't exist (hasn't been added to the current classroom as a student)?
    * What exactly does the Student Details menu look like? Is there a heading of some sort?

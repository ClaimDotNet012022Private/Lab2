As a user,
I need to be able to remove students from a classroom by student name,
So that I can reflect when a student drops from the class or was added by mistake.

Acceptance Criteria:
* When the Classroom Details menu displays, there is a menu item/option to remove a student.
* When the remove student option is selected, the user is asked for the name of a student to remove.
* Once the user enters the name of a student in the current classroom, the student with the given name is removed from the classroom's students.
* After the student is removed, the Classroom Details menu re-displays.

Notes:
* Removing a student from one classroom does not change any other classrooms.
* Some information may not be fully specified and is left up to the developer's discretion. In a real-world scenario, you would want to confirm these details with the client (probably through your scrum master or product owner). Examples include:
    * What is the exact wording of the remove student menu option?
    * What order does this menu item appear in, in relation to any other menu items?
    * What happens if no students have been added?
    * What happens if the user enters a name that doesn't exist (hasn't been added as a student in the current classroom)?

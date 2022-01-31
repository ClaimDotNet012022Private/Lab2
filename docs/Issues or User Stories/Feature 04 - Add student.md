As a user,
I need to be able to add students to a classroom by name,
So that I can manage the students in the classroom.

Acceptance Criteria:
* The Classroom Details menu displays, there is a menu item/option to add a student.
* When the add student option is selected, the user is asked for the name of a new student to add.
* Once the user enters a name, a new student is created with that name and added to the students that the classroom is managing.
* After the classroom is added, the main menu re-displays.

Notes:
* Each classroom needs its own collection of students.
* Adding a student to one classroom does not add them to any other classrooms.
* Within a given classroom, each student must have a unique name.
* A classroom can have a student with the same name as a student from a _different_ classroom. 
* If Classroom A has a student named John, and Classroom B also has a student named John, the two Johns are separate students and can have different property values. Any changes made or methods called for one John do not affect the other John.
* Some information may not be fully specified and is left up to the developer's discretion. In a real-world scenario, you would want to confirm these details with the client (probably through your scrum master or product owner). Examples include:
    * What is the exact wording of the add student menu option?
    * What happens if the user enters a name that already exists?
        * Display a message telling about the error? And then what? (Ask for a different name, and keep going until the user gets it right? Just go immediately back to the Classroom Details menu?)
        * Create the new student and replace the old one that had the same name? (I would prefer _not_ to do this)
        * Do nothing?

# .net-6-Api-With-CQRS
.net-6-Api-With-CQRS-Pattern-Using-MediatR
This is a Restuarant opening schedule api that accepts a Json formatted input/payload and put the schedule in a human readble format.
The project was created in .net 6
Docker support for windows was enabled for the project.
The Api was implemented using CQRS pattern using MediatR
A class library was added to implement the CQRS
In-Memory cahcing was also implemented in the Api so as fully exhibit the CQRS.
The AddSchedule method is a Post Method that takes the Json, transforms it to human readable format, addes to memory and then return it.
The GetSchedule simply get the schedule added to memory and will return a string message if there is no schedule in the memory.
Reason for the GetSchedule is to show Query segregation, while AddSchedule shows the Command segregation.
The Unix time in the Json was transformed to system time in 12 hours format 

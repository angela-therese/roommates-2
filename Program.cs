using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        /// 
        /// 
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true;  TrustServerCertificate = true;";

        static void Main(string[] args)
        {
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);
            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Room> allRooms = roomRepo.GetAll();
            List<Roommate> allRoommates = roommateRepo.GetAll();

         

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Name} has an Id of {room.Id} and a max occupancy of {room.MaxOccupancy}");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 1");

            Room singleRoom = roomRepo.GetById(1);

            Console.WriteLine($"Room number {singleRoom.Id}; {singleRoom.Name}; Max. Occupancy {singleRoom.MaxOccupancy}");

            Room smallBedroom = new Room
            {
                Name = "Small Bedroom",
                MaxOccupancy = 1
            };

            //roomRepo.Insert(smallBedroom);




            //Console.WriteLine("-------------------------------");
            // Console.WriteLine($"Added the new Room with id {bathroom.Id}");

            foreach (Roommate roommate in allRoommates)
           
                 {
                 Console.WriteLine($"{roommate.Firstname} {roommate.Lastname} is a roommate.");
                 }


                List<Roommate> roommateByRoomId = roommateRepo.GetRoommatesByRoomId(1);

                foreach (Roommate roomie in roommateByRoomId)
                {
                    Console.WriteLine($"{roomie.Firstname} is in Room 1.");
                }

            //QUESTION re:Room?? 

            //Roommate newRoomie = new Roommate
            //{
            //    Firstname = "Luca",
            //    Lastname = "Iafrate",
            //    RentPortion = 50,
            //    MovedInDate = new DateTime(2021, 1, 1, 0, 0, 0),
            //    Room = smallBedroom

            //};

            //roommateRepo.Insert(newRoomie);

            //Roommate luca = new Roommate
            //{
            //    Id = 15,
            //    Firstname = "Luca",
            //    Lastname = "Iafrate",
            //    RentPortion = 20,
            //    MovedInDate = new DateTime(2022, 1, 1, 0, 0, 0),
            //    Room = smallBedroom
            //};

            //roommateRepo.Update(luca);


        }
    }
    }

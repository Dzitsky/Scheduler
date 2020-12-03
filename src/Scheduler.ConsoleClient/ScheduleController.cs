using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Scheduler.Application;
using Scheduler.Application.Enums;
using Scheduler.Application.Extensions;
using Scheduler.ConsoleClient.Enums;
using Scheduler.ConsoleClient.Extensions;

namespace Scheduler.ConsoleClient
{
    public class ScheduleController
    {
        private readonly IScheduleService _scheduleManager;

        public ScheduleController()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IScheduleService, ScheduleService>()
                .BuildServiceProvider();

            _scheduleManager = serviceProvider.GetService<IScheduleService>();
        }

        public void Load()
        {
            _scheduleManager.Load();
        }

        public string ShowCommandList()
        {
            ShowHeader();

            Console.WriteLine("");
            Console.WriteLine("Select a command for the Scheduler:");
            Console.WriteLine("");

            foreach (ESchedulerCommandType command in Enum.GetValues(typeof(ESchedulerCommandType)))
            {
                Console.WriteLine(command.ToStr());
            }

            Console.WriteLine("");
            Console.Write("Input a command - ");

            return Console.ReadLine();
        }

        public void AddSchedule()
        {
            ShowHeader();

            Console.WriteLine("");
            Console.WriteLine("ADD a new schedule:");
            Console.WriteLine("");

            ScheduleData schedule = InputScheduleData();
            _scheduleManager.AddSchedule(schedule);
        }

        public void EditSchedule()
        {
            ShowHeader();

            Console.WriteLine("");
            Console.WriteLine("EDIT the schedule:");
            Console.WriteLine("");

            Console.Write("Input ID - ");

            string key = Console.ReadLine();

            if (Int32.TryParse(key, out int scheduleId))
            {
                if (_scheduleManager.HasScheduleById(scheduleId))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Input new data:");
                    Console.WriteLine("");

                    ScheduleData schedule = InputScheduleData();
                    _scheduleManager.EditSchedule(scheduleId, schedule);
                }
            }
        }

        public void DeleteSchedule()
        {
            ShowHeader();

            Console.WriteLine("");
            Console.WriteLine("DELETE the schedule:");
            Console.WriteLine("");

            Console.Write("Input ID - ");

            string key = Console.ReadLine();

            if (Int32.TryParse(key, out int scheduleId))
            {
                _scheduleManager.DeleteSchedule(scheduleId);
            }
        }

        public void ShowData()
        {
            var scheduleDataList = _scheduleManager.GetAll();

            if (scheduleDataList.Count == 0)
            {
                Console.Write("\t" + "Schedule list is empty." + "\n");
            }
            else
            {
                Console.WriteLine("{0,5} {1,20} {2,15} {3,15}", "ID", "TITLE", "PRIORITY", "DATE");

                foreach (var schedule in scheduleDataList)
                {
                    Console.WriteLine("{0,5} {1,20} {2,15} {3,15}", schedule.id, schedule.data.title, schedule.data.priority.ToStr(),
                        schedule.data.dateTime.ToString("dd.MM.yyyy"));
                }
            }
        }

        public void SortSchedule()
        {
            string key = ShowSortTypeList();

            if (Enum.TryParse(key, out ESchedulerSortType sortType))
            {
                switch (sortType)
                {
                    case ESchedulerSortType.SortById:
                        _scheduleManager.SortScheduleById();
                        break;

                    case ESchedulerSortType.SortByTitle:
                        _scheduleManager.SortScheduleByTitle();
                        break;

                    case ESchedulerSortType.SortByPriority:
                        _scheduleManager.SortScheduleByPriority();
                        break;

                    case ESchedulerSortType.SortByDateTime:
                        _scheduleManager.SortScheduleByDateTime();
                        break;

                    default:
                        //dp nothing
                        break;
                }
            }
        }

        private string ShowSortTypeList()
        {
            ShowHeader();

            Console.WriteLine("");
            Console.WriteLine("Select of sort type:");
            Console.WriteLine("");

            foreach (ESchedulerSortType sortType in Enum.GetValues(typeof(ESchedulerSortType)))
            {
                Console.WriteLine(sortType.ToStr());
            }

            Console.WriteLine("");
            Console.Write("Input a sort type - ");

            return Console.ReadLine();
        }

        private void ShowHeader()
        {
            Console.Clear();

            Console.WriteLine("Console Scheduler 1.0 :) ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");

            ShowData();

            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
        }

        private ScheduleData InputScheduleData()
        {
            Console.Write("Input \"Title\" - ");

            string title = Console.ReadLine();

            Console.WriteLine("");
            Console.Write("Priority: ");

            foreach (PriorityType priorityValue in Enum.GetValues(typeof(PriorityType)))
            {
                Console.Write((int)priorityValue + " [" + priorityValue.ToStr() + "]" + " ");
            }

            Console.Write(")\n");

            Console.Write("Input \"Priority key\" - ");

            PriorityType priority = GetPriority(Console.ReadLine());

            Console.WriteLine("");
            Console.Write("Date format [dd.mm.yyyy]\n");

            Console.Write("Input \"Date\" - ");

            DateTime dateTime = GetDateTime(Console.ReadLine());

            return new ScheduleData(title, priority, dateTime);
        }

        private PriorityType GetPriority(string key)
        {
            if (Enum.TryParse(key, out PriorityType priority))
            {
                return priority;
            }
            else
            {
                return PriorityType.Normal;
            }
        }

        private DateTime GetDateTime(string key)
        {
            if (DateTime.TryParse(key, out DateTime dateTime))
            {
                return dateTime;
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Scheduler.Application
{
    public class ScheduleService : IScheduleService
    {
        private const string SCHEDULE_LIST_JSON_PATH = "TestData.json";
        private const int MAX_ID_VALUE = 1000;

        private List<ScheduleInfo> scheduleDataList = new List<ScheduleInfo>();
        private List<int> scheduleIdList = new List<int>();

        private string GetJsonPath()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            return projectDirectory + "\\" + SCHEDULE_LIST_JSON_PATH;
        }

        public void Load()
        {
            string path = GetJsonPath();

            scheduleDataList.Clear();
            scheduleIdList.Clear();

            if (File.Exists(path))
            {
                string dataAsJson = File.ReadAllText(path);

                if (!string.IsNullOrEmpty(dataAsJson))
                {
                    scheduleDataList = JsonConvert.DeserializeObject<List<ScheduleInfo>>(dataAsJson);

                    for (int i = 0; i < scheduleDataList.Count; i++)
                    {
                        scheduleIdList.Add(scheduleDataList[i].id);
                    }
                }
            }
        }

        private void Save()
        {
            if (scheduleDataList.Count == 0)
                return;

            string path = GetJsonPath();

            string dataAsJson = JsonConvert.SerializeObject(scheduleDataList, Formatting.Indented);
            File.WriteAllText(path, dataAsJson);
        }

        public IList<ScheduleInfo> GetAll()
        {
            return scheduleDataList;
        }

        public bool HasScheduleById(int id)
        {
            return scheduleIdList.Contains(id);
        }

        public void AddSchedule(ScheduleData data)
        {
            int newId = GetNewId();

            ScheduleInfo schedule = new ScheduleInfo(newId, data);

            scheduleIdList.Add(newId);
            scheduleDataList.Add(schedule);

            Save();
        }

        public void DeleteSchedule(int id)
        {
            for (int i = 0; i < scheduleDataList.Count; i++)
            {
                ScheduleInfo schedule = scheduleDataList[i];
                if (schedule.id == id)
                {
                    scheduleDataList.RemoveAt(i);
                    scheduleIdList.Remove(id);

                    Save();

                    break;
                }
            }
        }

        public void EditSchedule(int id, ScheduleData data)
        {
            for (int i = 0; i < scheduleDataList.Count; i++)
            {
                if (scheduleDataList[i].id == id)
                {
                    scheduleDataList[i] = new ScheduleInfo(id, data);

                    Save();

                    break;
                }
            }
        }

        private int GetNewId()
        {
            Random rnd = new Random();

            int newId = rnd.Next(0, MAX_ID_VALUE);

            while (scheduleIdList.Contains(newId))
                newId = rnd.Next(0, MAX_ID_VALUE);

            return newId;
        }

        public void SortScheduleById()
        {
            scheduleDataList.Sort((data1, data2) => data1.id.CompareTo(data2.id));

            Save();
        }

        public void SortScheduleByTitle()
        {
            scheduleDataList.Sort((data1, data2) => data1.data.title.CompareTo(data2.data.title));

            Save();
        }

        public void SortScheduleByPriority()
        {
            scheduleDataList.Sort((data1, data2) => data1.data.priority.CompareTo(data2.data.priority));

            Save();
        }

        public void SortScheduleByDateTime()
        {
            scheduleDataList.Sort((data1, data2) => data1.data.dateTime.CompareTo(data2.data.dateTime));

            Save();
        }
    }
}
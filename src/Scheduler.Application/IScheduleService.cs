using System.Collections.Generic;

namespace Scheduler.Application
{
    public interface IScheduleService
    {
        /// <summary>
        /// Загрузка списка задач //TODO: Избыточный метод
        /// </summary>
        void Load();

        /// <summary>
        /// Получить все задачи расписания
        /// </summary>
        IList<ScheduleInfo> GetAll();

        /// <summary>
        /// Проверка существования задачи расписания
        /// </summary>
        /// <param name="id">Идетификатор задачи расписания</param>
        /// <returns></returns>
        bool HasScheduleById(int id);

        /// <summary>
        /// Добавить задачу расписания
        /// </summary>
        /// <param name="data">Задача расписания</param>
        void AddSchedule(ScheduleData data);

        /// <summary>
        /// Удалить задачу расписания
        /// </summary>
        /// <param name="id">Идентификатор задачи расписания</param>
        void DeleteSchedule(int id);

        /// <summary>
        /// Редактировать задачу расписания 
        /// </summary>
        /// <param name="id">Идетификатор задачи расписания</param> //TODO: Избыточный параметр
        /// <param name="data">Задача расписания</param>
        void EditSchedule(int id, ScheduleData data);

        /// <summary>
        /// Сортировать и сохранить расписание //TODO: Избытоные методы - объединить в один, передавать фильтр с типом сортировки
        /// </summary>
        void SortScheduleById();
        void SortScheduleByTitle();        
        void SortScheduleByPriority();
        void SortScheduleByDateTime();
    }
}

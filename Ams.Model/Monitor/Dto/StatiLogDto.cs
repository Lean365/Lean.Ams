namespace Ams.Model.Monitor.Dto
{
    public class StatiLogDto
    {
        /// <summary>
        /// 去重数据
        /// </summary>
        public int DeRepeatNum { get; set; }

        public int Num { get; set; }
        public DateTime Date { get; set; }
        public string WeekName { get; set; }
    }
}
namespace Ams.Model.Dto.Systems
{
    public class UserDto
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }

        /// <summary>
        /// 用户性别（0男 1女 2未知）
        /// </summary>
        public int Gender { get; set; }
    }
}
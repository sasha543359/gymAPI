namespace gymAPI.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }          // Идентификатор работника
        public string FirstName { get; set; }      // Имя
        public string LastName { get; set; }       // Фамилия
        public string Position { get; set; }       // Должность
        public string Email { get; set; }          // Электронная почта
        public string PhoneNumber { get; set; }    // Номер телефона
        public decimal Salary { get; set; }        // Зарплата
                                                   // Дополнительные поля в зависимости от требований проекта
    }
}

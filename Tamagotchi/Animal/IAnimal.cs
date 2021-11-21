using System;

namespace Tamagotchi.Animal
{
    /// <summary>
    /// Интерфейс животного.
    /// </summary>
    public interface IAnimal : IDisposable
    {
        /// <summary>
        /// Имя животного.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Возраст животного.
        /// </summary>
        public double Age { get; set; }

        /// <summary>
        /// Событие смерти животного.
        /// </summary>
        public event Action Death;

        /// <summary>
        /// Кушать.
        /// </summary>
        void Eat();

        /// <summary>
        /// Пить.
        /// </summary>
        void Drink();

        /// <summary>
        /// Спать.
        /// </summary>
        void Sleep();
 
        /// <summary>
        /// Играть.
        /// </summary>
        void Play();

        /// <summary>
        /// Говорить.
        /// </summary>
        void Speak();

        /// <summary>
        /// Получить состояние животного в данный момент.
        /// </summary>
        /// <returns>Состояние.</returns>
        string GetStatus();
    }
}

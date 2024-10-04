using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace snowy_ism
{
    public partial class snowForm : Form
    {
        // Инициализация
        private List<Snow> snows = new List<Snow>(); // Коллекция снежинок
        private Random random = new Random(); // Функция рандом
        private Timer timer = new Timer(); // Счётчик timer
        private readonly Bitmap snowImage = Properties.Resources.snow; // Image "snow"

        public snowForm()
        {
            InitializeComponent();
            // Настройка timer
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();

            // Генерация снежинок
            for (var i = 0; i < 30; i++) 
            {
                snows.Add(GenerateRandomSnow()); // Добавление снежинки после генерации
            }

            // Предотвращение мерцания
            DoubleBuffered = true;
        }

        // Генерация снежинки с функцией рандом
        private Snow GenerateRandomSnow()
        {
            var size = random.Next(10, 35); // Размер снежинки
            var x = random.Next(Width); // Позиция по X
            var y = random.Next(Height); // Позиция по Y
            var speed = random.Next(5, 10); // Скорость падения снежинки

            return new Snow(x, y, size, speed);
        }

        // Обработка события для счётчика
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var snow in snows)
            {
                snow.Y += snow.Speed;

                // Снежинка возвращается в исходное положение после падения
                if (snow.Y > Height)
                {
                    snow.Y = -snow.Size;
                    snow.X = random.Next(Width);
                }
            }
            // Обновление формы
            Invalidate();
        }

        // Отрисовка снежинок на форме
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics; // Инструмент для отрисовки

            foreach (var snow in snows)
            {
                g.DrawImage(snowImage, snow.X, snow.Y, snow.Size, snow.Size);
            }
        }

        private void snowForm_Load(object sender, EventArgs e)
        {

        }
    }
}

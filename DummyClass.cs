using System;

namespace BoringRPG
{
    internal class Mage : Archetype
    {
        // Конструктор: имя передаётся, остальные параметры фиксированы согласно таблице
        public Mage(string name) : base(name, 60, 100, 0, 35, 0.05)
        {
        }

        // Перегрузка оператора +: увеличивает HP на value и возвращает самого себя
        public static Mage operator +(Mage mage, int value)
        {
            mage.HP += value;
            return mage;
        }

        // Перегрузка оператора -: уменьшает HP на value и возвращает самого себя
        public static Mage operator -(Mage mage, int value)
        {
            mage.HP -= value;
            return mage;
        }

        // Оператор true: персонаж жив, если HP > 0
        public static bool operator true(Mage mage)
        {
            return mage.HP > 0;
        }

        // Оператор false: персонаж мёртв, если HP <= 0
        public static bool operator false(Mage mage)
        {
            return mage.HP <= 0;
        }

        // Реализация атаки: тратит 10 MP, если достаточно, наносит Damage цели, иначе урон 0
        public override void Hit(Archetype target)
        {
            if (MP >= 10)
            {
                MP -= 10;          // тратим ману
                target.HP -= Damage; // наносим обычный урон (без крита)
            }
            // При нехватке маны ничего не происходит
        }

        // Информация о персонаже
        public override string GetInfo()
        {
            return $"{Name} (Mage): HP {HP}, MP {MP}, Ammo {Ammo}, Damage {Damage}, Crit Chance {CritChance * 100}%";
        }
    }
}
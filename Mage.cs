using System;

namespace BoringRPG
{
  internal class Mage : Archetype
  {
    // Конструктор: вызывает базовый с параметрами из таблицы (HP=60, MP=100, Ammo=0, Damage=35, Crit=5%)
    public Mage(string name) : base(name, 60, 100, 0, 35, 0.05)
    {
    }

    // Оператор +: увеличивает HP мага на указанное число и возвращает того же мага (позволяет писать mage += 10)
    public static Mage operator +(Mage mage, int value)
    {
      mage.HP += value;
      return mage;
    }

    // Оператор -: уменьшает HP мага на указанное число и возвращает того же мага (mage -= 5)
    public static Mage operator -(Mage mage, int value)
    {
      mage.HP -= value;
      return mage;
    }

    // Оператор true: проверяет, жив ли маг (HP > 0). Используется в условных выражениях: if (mage) ...
    public static bool operator true(Mage mage)
    {
      return mage.HP > 0;
    }

    // Оператор false: проверяет, мёртв ли маг (HP <= 0). Требуется для парной работы с true.
    public static bool operator false(Mage mage)
    {
      return mage.HP <= 0;
    }

    // Реализация абстрактного метода Hit: атака цели
    public override void Hit(Archetype target)
    {
      // Если маны достаточно (10 и больше), тратим её и наносим обычный урон
      if (MP >= 10)
      {
        MP -= 10;                // расход магии
        target.HP -= Damage;      // наносим урон цели
      }
      // Если маны недостаточно – атака не происходит (урон 0)
    }

    // Реализация GetInfo: возвращает строку с текущими характеристиками мага
    public override string GetInfo()
    {
      // Умножаем CritChance на 100, чтобы показать проценты
      return $"{Name} (Mage): HP {HP}, MP {MP}, Ammo {Ammo}, Damage {Damage}, Crit Chance {CritChance * 100}%";
    }
  }

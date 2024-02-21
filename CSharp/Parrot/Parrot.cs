using System;
using System.Collections.Generic;

namespace Parrot
{
    public class Parrot
    {
        protected readonly bool _isNailed;
        protected readonly int _numberOfCoconuts;
        protected readonly ParrotTypeEnum _type;
        protected readonly double _voltage;

        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public virtual double GetSpeed()
        {
            switch (_type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot(_type, _numberOfCoconuts, _voltage, _isNailed).GetSpeed();
                case ParrotTypeEnum.AFRICAN:
                    return new AfricanParrot(_type, _numberOfCoconuts, _voltage, _isNailed).GetSpeed();
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return new NorwegianBlueParrot(_type, _numberOfCoconuts, _voltage, _isNailed).GetSpeed();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetBaseSpeed());
        }

        protected double GetLoadFactor()
        {
            return 9.0;
        }

        protected double GetBaseSpeed()
        {
            return 12.0;
        }

        public string GetCry()
        {
            string value;
            switch (_type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    value = "Sqoork!";
                    break;
                case ParrotTypeEnum.AFRICAN:
                    value = "Sqaark!";
                    break;
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    value = _voltage > 0 ? "Bzzzzzz" : "...";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return value;
        }
    }

    public class NorwegianBlueParrot : Parrot
    {
        public NorwegianBlueParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed) : base(type, numberOfCoconuts, voltage, isNailed)
        {
        }

        public override double GetSpeed()
        {
            return _isNailed ? 0 : GetBaseSpeed(_voltage);
        }
    }

    public class AfricanParrot : Parrot
    {
        
        public AfricanParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed) : base(type, numberOfCoconuts, voltage, isNailed)
        {
        }
        public override double GetSpeed()
        {
            return Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);
        }

    }

    public class EuropeanParrot : Parrot
    {
        public EuropeanParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
            : base(type, numberOfCoconuts, voltage, isNailed)
        {
        }

        public override double GetSpeed()
        {
            return GetBaseSpeed();
        }
    }
}
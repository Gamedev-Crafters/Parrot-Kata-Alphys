using System;

namespace Parrot
{
    public abstract class Parrot
    {
        protected readonly bool _isNailed;

        protected Parrot(bool isNailed)
        {
            _isNailed = isNailed;
        }

        public abstract double GetSpeed();

        public abstract string GetCry();
    }

    public class NorwegianBlueParrot : Parrot
    {
        private readonly double _voltage;
        
        public NorwegianBlueParrot(double voltage, bool isNailed) : base(
             isNailed)
        {
            _voltage = voltage;
        }

        public override double GetSpeed()
        {
            return _isNailed ? 0 : GetBaseSpeed();
        }

        private double GetBaseSpeed()
        {
            return Math.Min(24.0, _voltage * 12.0);
        }
        
        public override string GetCry()
        {
            return _voltage > 0 ? "Bzzzzzz" : "...";
        }
    }

    public class AfricanParrot : Parrot
    {
        private readonly int _numberOfCoconuts;
        public AfricanParrot(int numberOfCoconuts, bool isNailed) : base(
            isNailed)
        {
            _numberOfCoconuts = numberOfCoconuts;
        }

        public override double GetSpeed()
        {
            return Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);
        }

        private double GetBaseSpeed()
        {
            return 12.0;
        }
        
        public override string GetCry()
        {
            return "Sqaark!";
        }

        private double GetLoadFactor()
        {
            return 9.0;
        }
    }

    public class EuropeanParrot : Parrot
    {
        public EuropeanParrot(bool isNailed)
            : base( isNailed)
        {
        }
        public override double GetSpeed()
        {
            return GetBaseSpeed();
        }

        private double GetBaseSpeed()
        {
            return 12.0;
        }

        public override string GetCry()
        {
            return "Sqoork!";
        }
    }
}
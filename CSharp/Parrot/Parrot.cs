﻿using System;

namespace Parrot
{
    public abstract class Parrot
    {
        protected Parrot()
        {
            
        }

        public abstract double GetSpeed();

        public abstract string GetCry();
    }

    public class NorwegianBlueParrot : Parrot
    {
        private readonly double _voltage;
        private readonly bool _isNailed;
        
        public NorwegianBlueParrot(double voltage, bool isNailed) : base()
        {
            _voltage = voltage;
            _isNailed = isNailed;
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
        public AfricanParrot(int numberOfCoconuts) : base()
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
        public EuropeanParrot(): base()
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
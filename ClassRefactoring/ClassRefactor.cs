using System;
using System.Runtime.CompilerServices;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    public class SwallowFactory
    {
        //public Swallow GetSwallow(SwallowType swallowType) => new Swallow(swallowType);
        public Swallow GetSwallow(SwallowType swallowType)
        {
            switch (swallowType)
            {
                case SwallowType.African:
                    return new AfricanSwallow();
                case SwallowType. European: 
                    return new EuropeanSwallow();
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public class Swallow
    {
        public SwallowType Type { get; }
        public SwallowLoad Load { get; private set; }

        //public Swallow(SwallowType swallowType)
        //{
        //    Type = swallowType;
        //}

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public virtual double GetAirspeedVelocity()
        {
            throw new InvalidOperationException();
        }
       
    }

    public class AfricanSwallow : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            switch (Load)
            {
                case SwallowLoad.None:
                    return 22;
                case SwallowLoad.Coconut:
                    return 18;
                default:
                    throw new InvalidOperationException();
            }

        }
    }

    public class EuropeanSwallow : Swallow
    {
        public override double GetAirspeedVelocity()
        {
            switch (Load)
            {
                case SwallowLoad.None:
                    return 20;
                case SwallowLoad.Coconut:
                    return 16;
                default:
                    throw new InvalidOperationException();
            }

        }
    }
}
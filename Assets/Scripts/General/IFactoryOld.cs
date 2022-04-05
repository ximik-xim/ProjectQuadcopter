namespace Assets.Scripts
{
    public interface IFactoryOld { }

    public interface IFactoryOld<out TValue> : IFactoryOld
    {
        TValue Create();
    }

    public interface IFactoryOld<in TParam1, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param);
    }

    public interface IFactoryOld<in TParam1, in TParam2, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param1, TParam2 param2);
    }

    public interface IFactoryOld<in TParam1, in TParam2, in TParam3, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param1, TParam2 param2, TParam3 param3);
    }

    public interface IFactoryOld<in TParam1, in TParam2, in TParam3, in TParam4, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);
    }

    public interface IFactoryOld<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
    }

    public interface IFactoryOld<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);
    }

    public interface IFactoryOld<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);
    }

    public interface IFactoryOld<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);
    }

    public interface IFactoryOld<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, in TParam9, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9);
    }

    public interface IFactoryOld<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, in TParam9, in TParam10, out TValue> : IFactoryOld
    {
        TValue Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8, TParam9 param9, TParam10 param10);
    }
}

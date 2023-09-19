using Car_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ISingletonStartup
{
    void Initialize();
}

public class AppStart : ISingletonStartup
{

    public readonly IData _db;


    public AppStart(IData db) => _db = db;


    private bool isInitialized = false;

    public void Initialize()
    {
        if (!isInitialized)
        {
            _db.SeedData();


            isInitialized = true;
        }
    }
}

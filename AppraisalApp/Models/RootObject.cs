using System;
using System.Collections.Generic;

namespace ExtAppraisalApp.Models
{
    public class Year

    {

        public int yearId { get; set; }

        public string displayName { get; set; }

    }



    /// <summary>

    /// Contains Make Details

    /// </summary>



    public class Make

    {

        public int makeId { get; set; }

        public string displayName { get; set; }

    }

    /// <summary>

    /// Contains Model Details

    /// </summary>



    public class Model

    {

        public int modelId { get; set; }

        public string displayName { get; set; }

    }



    /// <summary>

    /// Contains Trim Details

    /// </summary>



    public class Trim

    {

        public int trimId { get; set; }

        public string displayName { get; set; }

    }

    /// <summary>

    /// Contains DriveTrain Details

    /// </summary>



    public class Drivetrain

    {

        public int drivetrainId { get; set; }

        public string displayName { get; set; }

    }



    /// <summary>

    /// Contains Engine Details

    /// </summary>



    public class Engine

    {

        public int engineId { get; set; }

        public string displayName { get; set; }

    }

    /// <summary>

    /// Contains Transmission Details

    /// </summary>



    public class Transmission

    {

        public int transmissionId { get; set; }

        public string displayName { get; set; }

    }



    /// <summary>

    /// Contain Possibility Details

    /// </summary>



    public class Possibility

    {

        public Year year { get; set; }

        public Make make { get; set; }

        public Model model { get; set; }

        public Trim trim { get; set; }

        public List<Drivetrain> drivetrains { get; set; }

        public List<Engine> engines { get; set; }

        public List<Transmission> transmissions { get; set; }



        //     public List<Option> options { get; set; }

        public color color { get; set; }

    }

    /// <summary>

    /// Contains list of possibilities

    /// </summary>



    public class Data

    {

        public List<Possibility> possibilities { get; set; }

    }

    /// <summary>

    /// Contains Data

    /// </summary>





    public class RootObject

    {

        public Data data { get; set; }

    }



    /// <summary>

    /// Contains Color Details

    /// </summary>





    public class color

    {

        public int colorId { get; set; }

    }
}

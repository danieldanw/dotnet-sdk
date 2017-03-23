﻿using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using System.Text;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoGeolocationTest
    {
        [Fact]
        public void SerializationTest()
        {
		    KondutoGeolocation geolocation = KondutoGeolocationFactory.Create();

            String geolocationJSON = KondutoUtils.LoadJson<KondutoGeolocation>(Resources.Load("geolocation")).ToJson();
		    
            try 
            {
			    Assert.Equal(geolocationJSON, geolocation.ToJson());
		    }
            catch (KondutoInvalidEntityException e) 
            {
			    Assert.True(false, "geolocation should be valid");
		    }

		    KondutoGeolocation geolocationDeserialized = KondutoModel.FromJson<KondutoGeolocation>(geolocationJSON);
            Assert.Equal(geolocation, geolocationDeserialized);
	    }
    }
}
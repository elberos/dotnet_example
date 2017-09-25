using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Reflection;
using Elberos.Orm;

namespace aspnetrazor{
	
	public class TestEntity : Entity{
		
		public long id = 0;
		public string name = "";
		public long f_inc = 0;
		public bool is_deleted = false;
		
		
		/**
		 * Returns Entity type
		 * 
		 * @return Type
		 */
		public override Type getEntityRepositoryType(){
			return typeof(TestEntityRepository);
		}
		
		
		
		/**
		 * Get entity value
		 *
		 * @param string field_name
		 * @param dynamic default_value
		 * @return dynamic
		 */
		public override dynamic getValue(string field_name, dynamic default_value = null){
			PropertyInfo property = this.GetType().GetProperty(field_name);
        	return property.GetValue(this, null);
		}
		
		
		/**
		 * Set entity value
		 *
		 * @param string field_name
		 * @param dynamic value
		 * @return dynamic
		 */
		public override void setValue(string field_name, dynamic value = null){
			PropertyInfo property = this.GetType().GetProperty(field_name);
        	property.SetValue(this, value, null);
		}
		
	}
}
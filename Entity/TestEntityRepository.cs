using System;
using System.Data.Common;
using System.Collections.Generic;
using Elberos.Orm;

namespace aspnetrazor{
	
	public class TestEntityRepository : EntityRepository{
		
		
		/**
		 * Returns Entity type
		 * 
		 * @return Type
		 */
		public override Type getEntityType(){
			return typeof(TestEntity);
		}
		
		
		/**
		 * Returns table name of the this entity
		 *
		 * @return string
		 */
	    public override string getTableName(){
			return "test";
		}
		
		
		/**
		 * Build struct fields
		 *
		 * @param StructBuilder $builder
		 */
	    public override void buildStruct(EntityStructBuilder builder){
			
			builder.addFields(new List<EntityFieldInfo>{
				
				// ID
				new EntityFieldInfo(new Dictionary<string, dynamic>{
					["name"] = "id",
					["comment"] = "Test ID",
					["primary"] = true,
					["dbtype"] = typeof(EntityBigIntType),
				}),
				
				
				// Name
				new EntityFieldInfo(new Dictionary<string, dynamic>{
					["name"] = "name",
					["comment"] = "name",
					["primary"] = true,
					["dbtype"] = typeof(EntityStringType),
				}),
				
			});
			
		}
		
	}
}
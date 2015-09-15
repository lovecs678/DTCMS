﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
	 	//td_property_good
		public partial class property_good
	{
   		public property_good(){}
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
		public bool Exists(int good_id,decimal property_value_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from td_property_good");
			strSql.Append(" where ");
			                                       strSql.Append(" good_id = @good_id and  ");
                                                                   strSql.Append(" property_value_id = @property_value_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@good_id", SqlDbType.Int,4),
					new SqlParameter("@property_value_id", SqlDbType.Decimal,9)			};
			parameters[0].Value = good_id;
			parameters[1].Value = property_value_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Model.property_good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into td_property_good(");			
            strSql.Append("good_id,property_value_id,property_id");
			strSql.Append(") values (");
            strSql.Append("@good_id,@property_value_id,@property_id");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@property_value_id", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@property_id", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.good_id;                        
            parameters[1].Value = model.property_value_id;                        
            parameters[2].Value = model.property_id;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update td_property_good set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.property_good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update td_property_good set ");
			                        
            strSql.Append(" good_id = @good_id , ");                                    
            strSql.Append(" property_value_id = @property_value_id , ");                                    
            strSql.Append(" property_id = @property_id  ");            			
			strSql.Append(" where good_id=@good_id and property_value_id=@property_value_id  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@good_id", SqlDbType.Int,4) ,            
                        new SqlParameter("@property_value_id", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@property_id", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.good_id;                        
            parameters[1].Value = model.property_value_id;                        
            parameters[2].Value = model.property_id;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int good_id,decimal property_value_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from td_property_good ");
			strSql.Append(" where good_id=@good_id and property_value_id=@property_value_id ");
						SqlParameter[] parameters = {
					new SqlParameter("@good_id", SqlDbType.Int,4),
					new SqlParameter("@property_value_id", SqlDbType.Decimal,9)			};
			parameters[0].Value = good_id;
			parameters[1].Value = property_value_id;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int good_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from td_property_good ");
            strSql.Append(" where good_id=@good_id");
            SqlParameter[] parameters = {
					new SqlParameter("@good_id", SqlDbType.Int,4)
                                        };
            parameters[0].Value = good_id; 


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.property_good GetModel(int good_id,decimal property_value_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select good_id, property_value_id, property_id  ");			
			strSql.Append("  from td_property_good ");
			strSql.Append(" where good_id=@good_id and property_value_id=@property_value_id ");
						SqlParameter[] parameters = {
					new SqlParameter("@good_id", SqlDbType.Int,4),
					new SqlParameter("@property_value_id", SqlDbType.Decimal,9)			};
			parameters[0].Value = good_id;
			parameters[1].Value = property_value_id;

			
			Model.property_good model=new Model.property_good();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["good_id"].ToString()!="")
				{
					model.good_id=int.Parse(ds.Tables[0].Rows[0]["good_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["property_value_id"].ToString()!="")
				{
					model.property_value_id=decimal.Parse(ds.Tables[0].Rows[0]["property_value_id"].ToString());
				}
																																if(ds.Tables[0].Rows[0]["property_id"].ToString()!="")
				{
					model.property_id=int.Parse(ds.Tables[0].Rows[0]["property_id"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM td_property_good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strSelect,string strWhere)
		{
		if(strSelect!=""){
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select "+strSelect);
			strSql.Append(" FROM td_property_good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
			}
			else
			return GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM td_property_good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strSelect,string strWhere,string filedOrder)
		{
		if(strSelect!="")
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(strSelect);
			strSql.Append(" FROM td_property_good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
			}
			else return GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得查询分页数据
		/// </summary>
		public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM td_property_good ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
		}
		
		
		/// <summary>
		/// 获得查询分页数据
		/// </summary>
		public DataSet GetList(int pageSize, int pageIndex,string strSelect, string strWhere, string filedOrder, out int recordCount)
		{
		if(strSelect!="")
		{
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select "+strSelect+" FROM td_property_good ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            }
            else return GetList( pageSize,  pageIndex,  strWhere, filedOrder,out recordCount);
		}
        #endregion  Method		
	}

}

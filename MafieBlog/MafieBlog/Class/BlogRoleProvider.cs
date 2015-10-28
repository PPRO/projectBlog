using DataAccess.Dao;
using DataAccess.Interface;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MafieBlog.Class
{
	public class BlogRoleProvider : RoleProvider
	{
		public override void AddUsersToRoles( string[] usernames, string[] roleNames )
		{
			throw new NotImplementedException();
		}

		public override string ApplicationName
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override void CreateRole( string roleName )
		{
			throw new NotImplementedException();
		}

		public override bool DeleteRole( string roleName, bool throwOnPopulatedRole )
		{
			throw new NotImplementedException();
		}

		public override string[] FindUsersInRole( string roleName, string usernameToMatch )
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}

		public override string[] GetRolesForUser( string username )
		{
			BlogUserDao blogUserDao = new BlogUserDao();
			BlogUser user = blogUserDao.GetByLogin(username);

			if (username == null)
			{
				return new string[]{};
			}

			return  new string[] {user.Role.Identificator};

		}

		public override string[] GetUsersInRole( string roleName )
		{
			throw new NotImplementedException();
		}

		public override bool IsUserInRole( string username, string roleName )
		{
			BlogUserDao blogUserDao = new BlogUserDao();
			BlogUser user = blogUserDao.GetByLogin( username );

			if (user == null)
			{
				return false;
			}

			return user.Role.Identificator == roleName;

		}

		public override void RemoveUsersFromRoles( string[] usernames, string[] roleNames )
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists( string roleName )
		{
			throw new NotImplementedException();
		}

		public int Id
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
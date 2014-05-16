using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Controllers.Admin
{
    public static class UrlHelperExtenion
    {
        public static string Action<T>(this UrlHelper url, Expression<Func<T, ActionResult>> actionSelector, RouteValueDictionary routeValues = null) where T : Controller
        {
            string controller;
            string action;

            routeValues = GetRouteValues(routeValues, actionSelector, out controller, out action);
            return url.Action(action, controller, routeValues);
        }

        /// <summary>
        /// Generates routevalues and controller and action strings from a strong typed lambda expression of a controllermethod.
        /// </summary>
        /// <typeparam name="T">Must be a Controller</typeparam>
        /// <param name="routeValues">Can be null or empty, but you can supply extra routevalues these win if generated values overlap</param>
        /// <param name="actionSelector">a lambda expression, must be a call to a ActionResult returning method</param>
        /// <param name="controller">the name of the controller</param>
        /// <param name="action">the name of the action</param>
        /// <returns></returns>
        public static RouteValueDictionary GetRouteValues<T>(
            RouteValueDictionary routeValues,
            Expression<Func<T, ActionResult>> actionSelector,
            out string controller,
            out string action)
        {
            var controllerType = typeof(T);
            if (routeValues == null)
            {
                routeValues = new RouteValueDictionary();
            }

            //The body of the expression must be a call to a method
            var call = actionSelector.Body as MethodCallExpression;
            if (call == null)
            {
                throw new ArgumentException("You must call a method of " + controllerType.Name, "actionSelector");
            }

            //the object being called must be the controller specified in <T>
            if (call.Object != null && call.Object.Type != controllerType)
            {
                throw new ArgumentException("You must call a method of " + controllerType.Name, "actionSelector");
            }

            //Remove the controller part of the name ProductController --> Product
            controller = controllerType.Name.EndsWith("Controller") ? controllerType.Name.Substring(0, controllerType.Name.Length - "Controller".Length) : controllerType.Name;
            //The action is the name of the method being called
            action = call.Method.Name;

            //get all arguments from the lambda expression
            var args = call.Arguments;

            //Get all parameters from the Action Method
            ParameterInfo[] parameters = call.Method.GetParameters();

            //pair the lambda arguments with the param names
            var pairs = args.Select((a, i) => new
            {
                Argument = a,
                ParamName = parameters[i].Name
            });


            foreach (var argumentParameterPair in pairs)
            {
                var name = argumentParameterPair.ParamName;

                if (routeValues.ContainsKey(name)) continue;
                //the argument could be a constant or a variable or a function and must be evaluated
                object value;
                //If it is a constant we can get the value immediately
                if (argumentParameterPair.Argument.NodeType == ExpressionType.Constant)
                {
                    var constant = argumentParameterPair.Argument as ConstantExpression;
                    value = constant??new object();
                }
                else 
                {

                    value = Expression.Lambda(argumentParameterPair.Argument).Compile().DynamicInvoke(null);
                }
                if (value != null)
                {
                    routeValues.Add(name, value);
                }
            }

            return routeValues;
        }
    }
}
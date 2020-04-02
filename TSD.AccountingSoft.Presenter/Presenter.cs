/***********************************************************************
 * <copyright file="Presenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, October 21, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TSD.AccountingSoft.Model;
//using KellermanSoftware.CompareNetObjects;

namespace TSD.AccountingSoft.Presenter
{
    /// <summary>
    /// class Presenter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Presenter<T>
    {
        private Dictionary<string, object> _originalValues = new Dictionary<string, object>();

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        protected static IModel Model { get; private set; }
        /// <summary>
        /// Initializes the <see cref="Presenter{T}"/> class.
        /// </summary>
        static Presenter()
        {
            Model = new Model.Model();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Presenter{T}"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public Presenter(T view)
        {
            View = view;
        }
        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        protected T View { get; private set; }

        /// <summary>
        /// The _original values
        /// </summary>
        public void Initialize(Dictionary<string, object> dictionary)
        {
            _originalValues = dictionary;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            _originalValues = new Dictionary<string, object>();
            PropertyInfo[] properties = typeof(T).GetProperties();

            // Save the current value of the properties to our dictionary.
            foreach (PropertyInfo property in properties)
            {
                _originalValues.Add(property.Name, property.GetValue(View, null));
            }
        }

        /// <summary>
        /// Determines whether [has data changed].
        /// </summary>
        /// <returns></returns>
        public bool HasDataChanged()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            var latestChanges = properties.ToDictionary(property => property.Name,
                property => property.GetValue(View, null));

            var compareLogic = new CompareObjects();
            var result = compareLogic.Compare(latestChanges, _originalValues);

            return !result;//.AreEqual;
        }

        /// <summary>
        /// Gets the changes.
        /// </summary>
        /// <returns></returns>
        public IList GetChanges()
        {
            // Save the current value of the properties to our dictionary.
            PropertyInfo[] properties = typeof(T).GetProperties();

            var latestChanges = properties.ToDictionary(property => property.Name,
                property => property.GetValue(View, null));

            // Filter properties by only getting what has changed
            var compareLogic = new CompareObjects();
            compareLogic.Compare(latestChanges, _originalValues);
            return compareLogic.Differences;
        }

    }
}

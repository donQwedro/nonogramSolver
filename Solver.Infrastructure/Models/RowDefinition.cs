﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Solver.Infrastructure.Models
{
    /// <summary>
    /// Represents definition for nonogram row
    /// </summary>
    public class RowDefinition
    {
        List<RowDefinitionItem> _blocks;

        public RowDefinition()
        {
            _blocks = new List<RowDefinitionItem>();
        }
        public RowDefinition(params int[] items)
            : this()
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public IEnumerable<RowDefinitionItem> Blocks
        {
            get { return _blocks; }
        }

        /// <summary>
        /// Returns true if blocks doesn't contain any definition item
        /// </summary>
        public bool IsEmpty
        {
            get { return !Blocks.Any(); }
        }

        public void AddItem(RowDefinitionItem item)
        {
            if (item.Length == 0 && _blocks.Any())
            {
                throw new ArgumentException("Row already contains Blocks. Zero length item is not allowed.", "item");
            }
            if (_blocks.Any(x => x.Length == 0))
            {
                throw new ArgumentException("Zero length item  has already been added. Can't add new item.", "item");
            }
            if (item.Length < 0)
            {
                throw new ArgumentException("Length can't be less than 0. Can't add new item.", "item");
            }
            _blocks.Add(item);
        }

        /// <summary>
        /// Adds block of specific length to the row definition
        /// </summary>
        /// <param name="length"></param>
        public void AddItem(int length)
        {
            AddItem(new RowDefinitionItem(length));
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.BinaryTree
{
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        public class Node<TValue>
        {
            public TValue Value { get; }
            public Node<TValue> LeftNode { get; set; }
            public Node<TValue> RightNode { get; set; }

            public Node(TValue value)
            {
                Value = value;
            }

            public Node() : this(default(TValue)) { }
        }

        private Node<T> root;

        #region Properties
        public IComparer<T> Comparer { get; set; }
        public int Count { get; private set; }
        #endregion

        #region Constructors
        public BinarySearchTree() : this(Comparer<T>.Default) { }

        public BinarySearchTree(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException(nameof(comparer));

            Comparer = comparer;
        }

        public BinarySearchTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default) { }

        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer) {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException();

            foreach (var element in collection)
                Add(element);
        }
        #endregion

        #region Public Methods
        public bool Add(T item)
        {
            if(ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            var node = new Node<T>(item);
            if (root == null)
            {
                root = node;
                Count++;
                return true;
            }
            else
            {
                AddTo(root, item);
                Count++;
                return true;
            }
        }

        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            var current = root;
            while (current != null)
            {
                var result = Comparer.Compare(item, current.Value);
                if (result == 0)
                    return true;
                current = result < 0 ? current.LeftNode : current.RightNode;
            }
            return false;
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public Node<T> Find(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            var current = root;
            while (current != null)
            {
                int result = Comparer.Compare(item, current.Value);
                if (result == 0)
                    return current;
                
                current = result < 0 ? current.LeftNode : current.RightNode;
            }
            return null;
        }

        public T MaxValue ()
        {
            if (ReferenceEquals(this, null))
                throw new ArgumentNullException();

            T max = root.Value;
            foreach(T x in this)
            {
                max = Comparer.Compare(x, max) > 0 ? x : max;
            }

            return max;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Inorder().GetEnumerator();
        }

        public IEnumerable<T> Inorder() => Inorder(root);
        public IEnumerable<T> Preorder() => Preorder(root);
        public IEnumerable<T> Postorder() => Postorder(root);
        #endregion

        #region PrivateMethod
        private void AddTo(Node<T> node, T value)
        {
            if (Comparer.Compare(value, node.Value) < 0)
            {
                if (ReferenceEquals(node.LeftNode, null))
                    node.LeftNode = new Node<T>(value);
                else
                    AddTo(node.LeftNode, value);
            }
            else
            {
                if (ReferenceEquals(node.RightNode, null))
                    node.RightNode = new Node<T>(value);
                else
                    AddTo(node.RightNode, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<T> Inorder(Node<T> node)
        {
            if (node == null) yield break;
            foreach (var n in Inorder(node.LeftNode))
                yield return n;

            yield return node.Value;
            foreach (var n in Inorder(node.RightNode))
                yield return n;
        }

        private IEnumerable<T> Preorder(Node<T> node)
        {
            if (node == null) yield break;
            yield return node.Value;
            foreach (var n in Preorder(node.LeftNode))
                yield return n;

            foreach (var n in Preorder(node.RightNode))
                yield return n;
        }

        private IEnumerable<T> Postorder(Node<T> node)
        {
            if (node == null) yield break;

            foreach (var n in Postorder(node.LeftNode))
                yield return n;

            foreach (var n in Postorder(node.RightNode))
                yield return n;
            yield return node.Value;
        }
        #endregion
    }
}

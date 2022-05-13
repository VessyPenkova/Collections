using System;
using System.Collections.Generic;
using System.Linq;
using Collections;
using NUnit.Framework;

namespace Collection_Tests
{
    public class Tests

    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Peter", 0, "Peter")]
        public void Test_Collection_Get_By_Valid_Index
            (string data, int index, string espected)
        {
            //Arrange Assert.Pass();
            var nums = new Collection<string>(data);
            //Act
            var actual = nums[index];
            //Assert
            Assert.AreEqual(espected, actual);
        }
        [Test]

        public void Test_Collection_EmptyConstructor()
        {
            var nums = new Collection<int>();
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(7);
            Assert.That(nums.ToString(), Is.EqualTo("[7]"));
        }

        [Test]
        public void Test_Collection_ConstructorMultiplyItems()
        {
            var nums = new Collection<int>(7, 8, 10);
            Assert.That(nums.ToString(), Is.EqualTo("[7, 8, 10]"));
        }

        [Test]
        public void Test_Collection_Add()
        {
            //Arrange Assert.Pass();
            var nums = new Collection<int>();
            //Act
            nums.Add(5);
            nums.Add(6);
            //Assert
            Assert.That(nums.Count == 2);
            Assert.AreEqual(nums[0], 5);
            Assert.AreEqual(nums[1], 6);
            Assert.That(nums.ToString(), Is.EqualTo("[5, 6]"));
        }
        [Test]
        public void Test_Collection_Count()
        {
            //Arrange Assert.Pass();
            var nums = new Collection<int>();
            //Act
            nums.Add(5);
            nums.Add(6);
            //Assert
            Assert.That(nums.Count == 2);
        }
        [Test]
        public void Test_Collection_Capacity_Posivive()
        {
            //Arrange Assert.Pass();
            var nums = new Collection<int>();
            //Act

            nums.Add(5);
            nums.Add(6);
            //Assert
            Assert.That(nums.Count == 2);
            Assert.That(nums.Capacity > nums.Count);
        }


        [Test]
        public void Test_Collection_AddWithGrow()
        {
            //Arrange Assert.Pass();
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();

            //Act
            nums.AddRange(newNums);

            //Assert
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            //Arrange Assert.Pass();
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();

            //Act
            nums.AddRange(newNums);

            //Assert
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }
        [Test]
        public void Test_Collection_GetByIndex()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");
            // Act
            var item0 = names[0];
            var item1 = names[1];
            // Assert
            Assert.That(item0, Is.EqualTo("Peter"));
            Assert.That(item1, Is.EqualTo("Maria"));
        }
        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            // Arrange
            var names = new Collection<string>("Bob", "Joe");
            // Act
            // Assert
            Assert.That(() => { var name = names[-1]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[2]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { var name = names[500]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(names.ToString(), Is.EqualTo("[Bob, Joe]"));
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            // Arrange
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();

            // Act

            // Assert
            Assert.That(nestedToString,
            Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));

        }
        [Test]
        public void Test_Collection_InsertAtStart()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");
            // Act          
            names.InsertAt(0 , "Maria");
            // Assert
            Assert.That(names[0], Is.EqualTo("Maria"));           
        }
        [Test]
        public void Test_Collection_InsertAtEnd() 
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");
            // Act
            int end = names.Count;
            names.InsertAt( end,"Maria");
            // Assert
            Assert.That(names[end], Is.EqualTo("Maria"));

        }
        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");
            // Act
            int end = names.Count;
           
            // Assert
            
            Assert.That(() => { names.InsertAt(end + 1, "Maria"); },
             Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]

        public void Test_Collection_EnsureCapacity()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");
            // Act
            int oldCapacity = names.Capacity;

            names.AddRange("Peter", "Maria");
            names.AddRange("Peter", "Maria");
            names.AddRange("Peter", "Maria");
            
            // Assert

            Assert.That(names.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(names.Capacity, Is.EqualTo ((oldCapacity)));
        }

        [Test]

        public void Test_Collection_Clear()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");

            // Act
            names.Clear();

            // Assert            
            Assert.That(names.Count, Is.EqualTo((0)));
        }

        [Test]

        public void Test_Collection_Exchange()
        {
            // Arrange
            var names = new Collection<string>("Peter", "Maria");

            // Act            
            names.Exchange(0 , 1);           
           
            // Assert            
            Assert.That(names[0] =="Maria");
        }

        [Test]
        [Timeout(1000)]

        public void Test_Collection_1MillionItems()
        {
            //Arrange
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            //Act
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            // Arrange
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);

        }
    }
}
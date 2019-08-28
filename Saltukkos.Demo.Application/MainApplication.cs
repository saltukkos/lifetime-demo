using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Saltukkos.Lifetime.Abstractions;

namespace Saltukkos.Demo.Application
{
    public class MainApplication
    {
        [NotNull]
        private readonly Dictionary<int, INestedLifetime> _lifetimes = new Dictionary<int, INestedLifetime>();

        [NotNull]
        private readonly ILifetime _lifetime;

        [NotNull]
        private readonly IFactory<string, IPage> _pageFactory;

        private int _pagesCounter;

        public MainApplication([NotNull] ILifetime lifetime, [NotNull] IFactory<string, IPage> pageFactory)
        {
            _lifetime = lifetime;
            _pageFactory = pageFactory;
        }

        public void Run()
        {
            Console.Out.WriteLine(@"Push '1' to create page, '2' to remove last page and any other key to exit");
            var working = true;
            while (working)
            {
                var consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.KeyChar)
                {
                    case '1':
                        CreatePage();
                        break;
                    case '2':
                        RemoveLastPage();
                        break;
                    default:
                        Console.Out.WriteLine("Exiting...");
                        working = false;
                        break;
                }
            }

            while (_pagesCounter > 0)
            {
                RemoveLastPage();
            }
        }

        private void CreatePage()
        {
            ++_pagesCounter;
            Console.Out.WriteLine("");
            Console.Out.WriteLine($"Creating page {_pagesCounter}");

            var pageLifetime = _lifetime.CreateLifetime();
            _pageFactory.Create(pageLifetime, $"Page{_pagesCounter}");
            _lifetimes.Add(_pagesCounter, pageLifetime);
        }

        private void RemoveLastPage()
        {
            Console.Out.WriteLine("");
            if (_pagesCounter == 0)
            {
                return;
            }

            Console.Out.WriteLine($"Removing page {_pagesCounter}");

            // ReSharper disable once PossibleNullReferenceException
            _lifetimes[_pagesCounter].Dispose();
            _lifetimes.Remove(_pagesCounter);
            --_pagesCounter;
        }
    }
}
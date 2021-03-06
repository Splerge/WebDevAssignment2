﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevAssignment2.Models;

namespace WebDevAssignment2.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebAssignmentContext(
                serviceProvider.GetRequiredService<DbContextOptions<WebAssignmentContext>>()))
            {
                // Look for any products.
                 /* if (context.Product.Any())
                {
                    return; // DB has been seeded.
                } */

                var products = new[]
                {
                    new Product
                    {
                        Name = "Rabbit"
                    },
                    new Product
                    {
                        Name = "Hat"
                    },
                    new Product
                    {
                        Name = "Svengali Deck"
                    },
                    new Product
                    {
                        Name = "Floating Hankerchief"
                    },
                    new Product
                    {
                        Name = "Wand"
                    },
                    new Product
                    {
                        Name = "Broomstick"
                    },
                    new Product
                    {
                        Name = "Bang Gun"
                    },
                    new Product
                    {
                        Name = "Cloak of Invisibility"
                    },
                    new Product
                    {
                        Name = "Elder Wand"
                    },
                    new Product
                    {
                        Name = "Resurrection Stone"
                    }
                };

                context.Product.AddRange(products);

                var i = 0;
                context.OwnerInventory.AddRange(
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 20
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 50
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 100
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 150
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 40
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 10
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 5
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 0
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 0
                    },
                    new OwnerInventory
                    {
                        Product = products[i],
                        StockLevel = 0
                    }
                );

                i = 0;
                var stores = new[]
                {
                    new Store
                    {
                        Name = "Melbourne CBD",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 15
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 10
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 1
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 1
                            },
                            new StoreInventory
                            {
                                Product = products[i],
                                StockLevel = 1
                            },
                        }
                    },
                    new Store
                    {
                        Name = "North Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[0],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "East Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[1],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "South Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[2],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "West Melbourne"
                    }
                };

                context.Store.AddRange(stores);

                context.SaveChanges();
            }
        }
    }
}

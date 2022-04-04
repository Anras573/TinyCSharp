// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using TinyRenderer;
using TinyRenderer.Canvas;

Console.WriteLine("Hello, World!");

var red = new Color(255, 0, 0);
var white = new Color(255, 255, 255);
var filename = @"C:\tobedeleted\image.png";

var image = new Image(800, 800);
var renderer = new Renderer(image);

var model = Model.Parse("Files/african_head.obj");

renderer.DrawModelFrame(model, white);

image.FlipVertically();

image.Save(filename);

Console.WriteLine("Image rendered, opening now...");

Process.Start("explorer.exe", filename);
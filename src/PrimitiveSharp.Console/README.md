# PrimitiveSharp.Console

### Command-line Usage

Run it on your own images! Compile solution with Visual Studio.
Dependences: 

[CommandLineUtils](https://github.com/natemcmaster/CommandLineUtils)

Usage:    
    primitive -i input.png -o output.png -n 100

Small input images should be used (like 256x256px). You don't need the detail anyway and the code will run faster.

| Flag | Default | Description |
| --- | --- | --- |
| `i` | n/a | input file |
| `o` | n/a | output file |
| `n` | n/a | number of shapes |
| `m` | 1 | mode: <br>0=combo, <br>1=Triangle, <br>2=Rectangle, <br>3=Rotated Rectangle, <br>4=Ellipse, <br>5=Rotated Ellipse, <br>6=Circle, <br>7=Bezier Quadratic, <br>8=Quadrilateral, <br>9=Square, <br>10=Pentagon, <br>11=Hexagon, <br>12=Octagon, <br>13=Four-pointed star, <br>14=Pentagram, <br>15=Hexagram |
| `rep` | 0 | add N extra shapes each iteration with reduced search (mostly good for beziers) |
| `nth` | 1 | save every Nth frame (only when `{0}` is in output path) |
| `r` | 256 | resize large input images to this size before processing |
| `s` | 1024 | output image size |
| `a` | 128 | color alpha (use `0` to let the algorithm choose alpha for each shape) |
| `bg` | avg | starting background color (hex) |
| `j` | 0 | number of parallel workers (default uses all cores) |
| `p` | 1000 | shape probe count |
| `age` | 100 | shape age |

### Output Formats

Depending on the output filename extension provided, you can produce different types of output.

- `PNG`: raster output
- `JPG`: raster output
- `SVG`: vector output
- `GIF`: animated output showing shapes being added

For PNG and SVG outputs, you can also include `{0}`, `{0:000}`, etc. in the filename. In this case, each frame will be saved separately.

You can use the `-o` flag multiple times. This way you can save both a PNG and an SVG, for example.

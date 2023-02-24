# UrlShortener

Simple Url shortening web-API service implemented in C#. It convert same long urls to different short urls.

## Try it

All you need is [Docker](https://www.docker.com/products/docker-desktop/)

From /**common**/ directory run:

~~~bash
docker compose -f dc-prod.yml up -d
~~~

Now you can get a short uri for any url with a simple post request:

~~~bash
http://localhost/shorten
~~~

Body with url which needs to be shortened:

~~~json
{
  "url": "https://www.microsoft.com/"
}
~~~

Example of response:

~~~json
{
    "shortUrl": "101wyrk"
}
~~~

After that, just open in browser the `localhost/101wyrk` and you will be redirected to `microsoft.com`

## Scale it

By default, when `dc-prod.yml` is up, one shorten-service instance and one redirect-service instance will be launched. You can scale it with:

~~~bash
docker compose -f dc-prod.yml up -d --scale url-generator-prod=3 --scale url-redirector-prod=2
~~~

The command above will start 3 instances of shorten-service and 2 instances of redirect-service.

## Debug it

From /**common**/ directory run:

~~~bash
docker compose -f dc-local.yml up -d
~~~

Open solution file `\src\Volkin.UrlShortener.sln` with Visual Studio/Rider/etc and have fun

## How It works

The **purple** steps describe the process of getting *short* link *by a long*.

The **green** steps describe the process of getting *source* link *by a short*.

![architecture](common\imgs\architecture.png)
---
layout: page
title: Home
title-image: /assets/icons/logo_260x260.png
---
{% include JB/setup %}

<div>
TEST

<ul>
{% for item in site.data.sloader.Data.Blog.FeedItems %}
  <li>

      {{ item.Title }}

  </li>
{% endfor %}
</ul>

Sloder

<ul>
{% for item in site.data.Sloader.Data.Blog.FeedItems %}
  <li>

      {{ item.Title }}

  </li>
{% endfor %}
</ul>

</div>

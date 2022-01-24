---
layout: page
---
{% include JB/setup %}

<section>
    <h2><strong>//</strong> Blog</h2>

    <div class="row">

        <div class="col-md-12">

            <div class="list-group">
                <a href="https://blog.codeinside.eu" class="list-group-item active">
                    <h4 class="list-group-item-heading">Code Inside Blog</h4>
                </a>
				
				{% for feedItem in site.data.Sloader.Data.Blog.FeedItems limit: 5 %}
					<a href="{{ feedItem.Href }}" class="list-group-item">
                        <h4 class="list-group-item-heading">{{ feedItem.Title }}</h4>
                        <p class="list-group-item-text">
                            Published on {{ feedItem.PublishedOn | date_to_long_string }}
                        </p>
                    </a>
				{% endfor %}
            </div>
        </div>
    </div>
</section>

<section>
    <h2><strong>//</strong> Social</h2>
    <div class="row"> 
        <div class="col-md-12">
            <div class="list-group">
                <a href="https://blog.codeinside.eu" class="list-group-item active">
                    <h4 class="list-group-item-heading">Code Inside Team @ Twitter</h4>
                </a>
				
				{% for tweetItem in site.data.Sloader.Data.Twitter.Tweets limit: 10 %}
					<a href="https://twitter.com/{{ tweetItem.UserScreenname }}/status/{{ tweetItem.Id }}" class="list-group-item">
                        <h4 class="list-group-item-heading">{{ tweetItem.Text }}</h4>
                        <p class="list-group-item-text">
                            @{{ tweetItem.UserScreenname }} | Published on {{ tweetItem.CreatedAt | date_to_long_string }}
                        </p>
                    </a>
				{% endfor %}
            </div>
        </div>
	</div>
	<div class="row">  
        <div class="col-md-12">
            <div class="list-group">
                <a href="https://github.com/Code-Inside/" class="list-group-item active">
                    <h4 class="list-group-item-heading">Code Inside Team @ GitHub</h4>
                </a>
				
				{% for eventItem in site.data.Sloader.Data.GitHubEventsUser.Events limit: 10 %}
				<a href="{{ eventItem.RelatedUrl }}" class="list-group-item">
                        		<h4 class="list-group-item-heading">
					{% if eventItem.Type == "PushEvent" %}
						<i class="fa fa-cloud-upload" aria-hidden="true"></i>
					{% endif %}
					{% if eventItem.Type == "PullRequestEvent" %}
						<i class="fa fa-code-fork" aria-hidden="true"></i>
					{% endif %}
					{% if eventItem.Type == "WatchEvent" %}
						<i class="fa fa-eye" aria-hidden="true"></i>
					{% endif %}
					{% if eventItem.Type == "IssuesEvent" %}
						<i class="fa fa-sticky-note-o" aria-hidden="true"></i>
					{% endif %}
					{% if eventItem.Type == "IssueCommentEvent" %}
						<i class="fa fa-commenting" aria-hidden="true"></i>
					{% endif %}
					{% if eventItem.Type == "CreateEvent" %}
						<i class="fa fa-plus" aria-hidden="true"></i>
					{% endif %}
					{% if eventItem.Type == "DeleteEvent" %}
						<i class="fa fa-minus" aria-hidden="true"></i>
					{% endif %}
					{% if eventItem.Type == "ForkEvent" %}
						<i class="fa fa-code-fork" aria-hidden="true"></i>
					{% endif %}
					
					{{ eventItem.RelatedDescription }}
					
					</h4>
                        		<p class="list-group-item-text">
                            			on {{ eventItem.CreatedAt | date_to_long_string }} by {{ eventItem.Actor }}
                        		</p>
                    		</a>
				{% endfor %}
            </div>
        </div>
    </div>
</section>

<section>
    <h2><strong>//</strong>&nbsp;Team</h2>

    <div class="row">
            <div class="col-md-4">
                <div class="thumbnail">
                    <img width="300" height="200" alt="Robert Muehsig" src="{{BASE_Path}}assets/icons/rmuehsig.png">
                    <div class="caption">
                        <h3>Robert Muehsig</h3>
                        <p>Software Developer - from Saxony, Germany. ASP.NET MVP &amp; Web Geek.</p>
                        <p>
                                <a href="https://twitter.com/robert0muehsig" class="btn btn-xs btn-info">
                                    Twitter
                                </a>
                                <a href="https://github.com/robertmuehsig" class="btn btn-xs btn-info">
                                    GitHub
                                </a>
                                <a href="http://mvp.microsoft.com/en-us/mvp/Robert Muehsig-4020675" class="btn btn-xs btn-info">
                                    Microsoft MVP
                                </a>
                                <a href="https://www.xing.com/profile/Robert_Muehsig" class="btn btn-xs btn-info">
                                    XING
                                </a>
                                <a href="https://speakerdeck.com/robertmuehsig" class="btn btn-xs btn-info">
                                    SpeakerDeck
                                </a>
                                <a href="https://stackoverflow.com/users/602449/robert-muehsig" class="btn btn-xs btn-info">
                                    Stack Overflow
                                </a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail">
                    <img width="300" height="200" alt="Oliver Guhr" src="{{BASE_Path}}assets/icons/oguhr.png">
                    <div class="caption">
                        <h3>Oliver Guhr</h3>
                        <p>Software Developer - from Dresden, Germany. Co-Blog-Author.</p>
                        <p>
				<a href="https://www.oliverguhr.eu" class="btn btn-xs btn-info">
                                    Olivers Blog
                                </a>
                                <a href="https://twitter.com/oliverguhr" class="btn btn-xs btn-info">
                                    Twitter
                                </a>
                                <a href="https://github.com/oliverguhr" class="btn btn-xs btn-info">
                                    GitHub
                                </a>
                                <a href="https://www.xing.com/profile/Oliver_Guhr" class="btn btn-xs btn-info">
                                    XING
                                </a>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail">
                    <img width="300" height="200" alt="Antje Kilian" src="{{BASE_Path}}assets/icons/akilian.png">
                    <div class="caption">
                        <h3>Antje Kilian</h3>
                        <p>IT-Law consultant, translator and Geek Girl - from Dresden, Germany.</p>
                        <p>
                                <a href="https://twitter.com/Antje_Kilian" class="btn btn-xs btn-info">
                                    Twitter
                                </a>
                                <a href="https://www.xing.com/profile/Antje_Kilian5" class="btn btn-xs btn-info">
                                    XING
                                </a>
                        </p>
                    </div>
                </div>
            </div>
    </div>
</section>

from django.conf.urls.defaults import patterns, include, url

# Uncomment the next two lines to enable the admin:
from django.contrib import admin
admin.autodiscover()

urlpatterns = patterns('',
    # Examples:
    # url(r'^$', 'websitecode.views.home', name='home'),
    # url(r'^websitecode/', include('websitecode.foo.urls')),
    url(r'^prizes/create', 'fe.views.create_prize'),
    url(r'^prizes/(?P<prize_id>\d+)/$', 'fe.views.detail'),
    url(r'^prizes/', 'fe.views.index'),
    url(r'^account/(?P<username>\w+)/login/', 'fe.account.Login'),
    url(r'^account/(?P<username>\w*)/logout/', 'fe.account.Logout'),

    # Uncomment the admin/doc line below to enable admin documentation:
    # url(r'^admin/doc/', include('django.contrib.admindocs.urls')),

    # Uncomment the next line to enable the admin:
    url(r'^admin/', include(admin.site.urls)),
)

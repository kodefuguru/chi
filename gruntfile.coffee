module.exports = (grunt) ->
    "use strict"
    
    grunt.initConfig

        # Metadata
        pkg: grunt.file.readJSON 'package.json'
        copyright: "Copyright <%= grunt.template.today('yyyy') %>"
        banner: """@*!
                    * <%= pkg.title %> v<%= pkg.version %> (<%= pkg.homepage %>)
                    * <%= copyright %> <%= pkg.author.name %>
                    * Licensed under <%= _.pluck(pkg.licenses, 'url').join(', ') %>
                    *@

                """

        # Task configuration
        clean: 
            build: ['build/']
            dist: ['dist/']        
            src: ['src/Chi/bin', 'src/Chi/obj', 'src/Chi.Tests/bin', 'src/Chi.Tests/obj']
        copy: 
            src:
                expand: true
                cwd: 'src/Chi/bin/release/'
                src: ['Chi.dll']
                dest: 'build/lib/'
        msbuild:
            release:
                options:
                    projectConfiguration: 'Release'
                src: ['src/Chi.sln']
        nugetpack:
            dist:
                src: 'build/Package.nuspec'
                dest: 'dist/'
        template:
            options:
                data:
                    author: '<%= pkg.author.name %>'
                    company: 'kodefuguru'
                    copyright: '<%= copyright %>'
                    description: '<%= pkg.description %>'
                    icon: 'http://kodefuguru.com/chi/logo'
                    id: '<%= pkg.name %>'
                    language: 'en-US'
                    neutralLanguage: 'en'
                    licenseUrl: "<%= _.pluck(pkg.licenses, 'url')[0] %>"
                    projectUrl: '<%= pkg.homepage %>'
                    requireLicenseAcceptance: 'false'
                    tags: "<%= pkg.keywords.join(' ') %>"
                    title: "<%= pkg.title %>"
                    version: '<%= pkg.version %>'
            nuspec:
                src: 'templates/Package.nuspec'
                dest: 'build/Package.nuspec'
            assemblyinfo:
                src: 'templates/AssemblyInfo.cs'
                dest: 'src/Chi/Properties/AssemblyInfo.cs'
                    
        watch: 
            src: 
                files: '<%= copy.src.src %>'
                tasks: ['build']

    grunt.loadNpmTasks 'grunt-nuget'
    grunt.loadNpmTasks 'grunt-msbuild'
    grunt.loadNpmTasks 'grunt-template'
    grunt.loadNpmTasks 'grunt-contrib-clean'
    grunt.loadNpmTasks 'grunt-contrib-copy'
    grunt.loadNpmTasks 'grunt-contrib-watch'

    grunt.registerTask 'test', []
    grunt.registerTask 'build', ['clean:build', 'clean:src', 'template:assemblyinfo', 'msbuild:release', 'copy:src', 'template:nuspec']
    grunt.registerTask 'dist', ['clean:dist', 'nugetpack']
    grunt.registerTask 'default', ['build', 'test', 'dist']
 
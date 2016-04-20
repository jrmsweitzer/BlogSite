/// <binding AfterBuild='TSLint:All' ProjectOpened='TSLint:Watch' />
var gulp = require('gulp');
var plumber = require("gulp-plumber");
var newer = require("gulp-newer");
var watch = require("gulp-watch");
var tslint = require("gulp-tslint");

//Paths to include/exclude
var TYPE_SCRIPT_FILES = ["scripts/**/*.ts"];

// File locations
var BIN = "bin";

// Our TSLint Settings
var TYPE_SCRIPT_REPORT = tslint.report("prose", {
    emitError: false,
    reportLimit: 50
});

// The actual task to run
gulp.task('TSLint:All', function () {
    return gulp.src(TYPE_SCRIPT_FILES)
        .pipe(plumber())
        .pipe(tslint())
        .pipe(TYPE_SCRIPT_REPORT);
});

// Listens for new (updated) typescript files and runs through TSlint
gulp.task("TSLint:Newer", [], function (done) {
    return gulp.src(TYPE_SCRIPT_FILES)
        .pipe(plumber())
        .pipe(newer(BIN))
        .pipe(tslint())
        .pipe(TYPE_SCRIPT_REPORT)
        .pipe(gulp.dest(BIN));
});

//This task runs when the project opens. When any file changes, it will be run through TSLint
gulp.task('TSLint:Watch', function () {
    return gulp.src(TYPE_SCRIPT_FILES)
        .pipe(watch(TYPE_SCRIPT_FILES))
        .pipe(plumber())
        .pipe(tslint())
        .pipe(TYPE_SCRIPT_REPORT)
        .pipe(gulp.dest(BIN));
});

gulp.task('moveToLibs', function (done) {
    gulp.src([
      'node_modules/angular2/bundles/js',
      'node_modules/angular2/bundles/angular2.*.js*',
      'node_modules/angular2/bundles/angular2-polyfills.js',
      'node_modules/angular2/bundles/http.*.js*',
      'node_modules/angular2/router.js',
      'node_modules/angular2/bundles/router.*.js*',
      'node_modules/es6-shim/es6-shim.min.js*',
      'node_modules/es6-shim/es6-shim.map',
      'node_modules/angular2/es6/dev/src/testing/shims_for_IE.js',
      'node_modules/systemjs/dist/*.*',
      'node_modules/jquery/dist/jquery.*js',
      'node_modules/bootstrap/dist/js/bootstrap*.js',
      'node_modules/rxjs/bundles/Rx.js'
    ]).pipe(gulp.dest('./wwwroot/libs/'));

    gulp.src([
      'node_modules/bootstrap/dist/css/bootstrap.css'
    ]).pipe(gulp.dest('./wwwroot/libs/css'));
});

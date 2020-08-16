/// <binding />
var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('watch', function () {
    gulp.watch('./wwwroot/css/sass/*.scss', ['sass']);
});

gulp.task('sass', function () {
    gulp.src('./wwwroot/css/sass/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('./wwwroot/css'));

});

gulp.task('default', ['sass', 'watch']);

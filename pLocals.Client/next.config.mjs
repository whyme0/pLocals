/** @type {import('next').NextConfig} */
const nextConfig = {
  output: 'standalone',
  env: {
      NEXT_PUBLIC_API_FOR_CLIENT: "http://localhost:5187", // not relate to docker's envs
  }
};

export default nextConfig;
